using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Threading;
using Comuns;

namespace Inversions
{
    public partial class Moviment
    {
        #region *** Atributs ***

        [Description("S'utilitza en un DataGrid")]
        public Producte _ProducteTraspasOrigen
        {
            get { return TipusMoviment == TipusMoviment.Compra ? _ProducteTraspas : null; }
        }

        [Description("S'utilitza en un DataGrid")]
        public Producte _ProducteTraspasDesti
        {
            get { return TipusMoviment == TipusMoviment.Venda ? _ProducteTraspas : null; }
        }

        [Description("S'utilitza en un DataGrid")]
        public double _ImportBrut
        {
            get
            {
                double result;
                if (Utilitats.EsZero(Participacions))
                {
                    result = PreuParticipacio;
                }
                else
                {
                    result = PreuParticipacio * Participacions;
                }
                return result;
            }
        }

        [Description("S'utilitza en un DataGrid")]
        public double _ImportNet
        {
            get
            {
                double result;
                if (Utilitats.EsZero(Participacions))
                {
                    result = PreuParticipacio;
                }
                else
                {
                    if (_EsCompra)
                        result = PreuParticipacio * Participacions + Despeses.GetValueOrDefault();
                    else if (_EsVenda)
                        result = PreuParticipacio * Participacions - Despeses.GetValueOrDefault();
                    else
                        result = PreuParticipacio * Participacions;
                }
                return result;
            }
        }

        static internal bool AmbCartera;
        static internal bool AmbDividents;

        [Description("S'utilitza en un DataGrid")]
        public double __PigDeLaCompra
        {
            get { return pigDeLaCompraEsElBooooo(AmbCartera, false, null, true, AmbDividents); }
        }

        [Description("S'utilitza en un DataGrid")]
        public double __PigDeLaCompraOrigen
        {
            get { return pigDeLaCompraEsElBooooo(AmbCartera, true, null, true, AmbDividents); }
        }


        private Producte _ProducteTraspas
        {
            get { return RefTraspas != null ? RefTraspas.Prod : null; }
        }

        /// <summary>
        /// Torna tipus movimen en string i indica els traspassos.
        /// </summary>
        [Description("S'utilitza en un DataGrid")]
        public string _TipusMoviment
        {
            get
            {
                if (TipusMoviment == TipusMoviment.Dividends)
                {
                    return TipusMoviment.Dividends.ToString();
                }

                if (TipusMoviment == TipusMoviment.Split)
                {
                    return TipusMoviment.Split.ToString();
                }

                if (TipusMoviment == TipusMoviment.ContraSplit)
                {
                    return TipusMoviment.ContraSplit.ToString();
                }

                if (TipusMoviment == TipusMoviment.Compra)
                {
                    return _EsTraspas ? "Traspàs C" : TipusMoviment.Compra.ToString();
                }

                if (TipusMoviment == TipusMoviment.Venda)
                {
                    return _EsTraspas ? "Traspàs V" : TipusMoviment.Venda.ToString();
                }

                throw new Exception("No hauria d'arribar aquí");
            }
        }

        public bool _EsTraspas
        {
            get { return RefTraspas != null; }
        }

        /// <summary>
        /// Pot ser compra o traspas compra.
        /// </summary>
        public bool _EsCompra
        {
            get { return TipusMoviment == TipusMoviment.Compra; }
        }

        /// <summary>
        /// Compra. No traspàs.
        /// </summary>
        public bool _EsCompraReal
        {
            get { return _EsCompra && !_EsTraspas; }
        }

        /// <summary>
        /// Pot ser venda o traspàs venda.
        /// </summary>
        public bool _EsVenda
        {
            get { return TipusMoviment == TipusMoviment.Venda; }
        }

        /// <summary>
        /// Venda. no traspàs
        /// </summary>
        public bool _EsVendaReal
        {
            get { return _EsVenda && !_EsTraspas; }
        }

        public bool _EsDividents
        {
            get { return TipusMoviment == TipusMoviment.Dividends; }
        }

        public double _PreuParticipacio
        {
            get { return PreuParticipacio; }
        }


        /// <summary>
        /// Son les participacions utilitzades en moviments anteriors.
        /// </summary>
        public double _ParticipacionsOcupades
        {
            get
            {
                if (_EsCompra)
                    return DesglosCompres.Sum(s => s._ParticipacionsOcupades);
                if (_EsVenda)
                    return vParticipacionsOcupades;

                throw new Exception("El moviment ha de ser una compra o una venda.");
            }
            set
            {
                if (_EsCompra)
                {
                    var valor = value;
                    foreach (var desglosCompra in DesglosCompres.OrderBy(o => o._DataOrig))
                    {
                        if (desglosCompra._ParticipacionsDisponibles >= valor)
                        {
                            desglosCompra._ParticipacionsOcupades = valor;
                            valor = 0;
                            break;
                        }
                        else
                        {
                            var partsDisp = desglosCompra._ParticipacionsDisponibles;
                            desglosCompra._ParticipacionsOcupades = partsDisp;
                            valor -= partsDisp;
                        }
                    }
                    if (Utilitats.ComparaNumeros(valor, 0) > 0)
                        throw new Exception("'value' no s'ha repartit completament");
                }
                else if (_EsVenda)
                {
                    if (Utilitats.ComparaNumeros(value, Participacions - vParticipacionsUtilitzades) > 0)
                        throw new Exception("El valor no pot ser superior a 'Participacions disponibles'");

                    vParticipacionsOcupades = value;
                }
                else
                    throw new Exception("El moviment ha de ser una venda. Per assignar un valor a la compra sha de fer a través de 'DesgloçCompra'");
            }
        }
        private double vParticipacionsOcupades;

        /// <summary>
        /// Son les participacions utilitzades en aquest moviment.
        /// </summary>
        public double _ParticipacionsUtilitzades
        {
            get
            {
                if (_EsCompra || TipusMoviment == TipusMoviment.Split || TipusMoviment == TipusMoviment.ContraSplit)
                    return DesglosCompres.Sum(s => s._ParticipacionsUtilitzades);
                if (_EsVenda)
                    return vParticipacionsUtilitzades;

                throw new Exception("El moviment ha de ser una compra o una venda.");
            }
            set
            {
                if (_EsCompra)
                {
                    var valor = value;
                    foreach (var desglosCompra in DesglosCompres.OrderBy(o => o._DataOrig))
                    {
                        if (desglosCompra._ParticipacionsDisponibles >= valor)
                        {
                            desglosCompra._ParticipacionsUtilitzades = valor;
                            valor = 0;
                            break;
                        }
                        else
                        {
                            var partsDisp = desglosCompra._ParticipacionsDisponibles;
                            desglosCompra._ParticipacionsUtilitzades = partsDisp;
                            valor -= partsDisp;
                        }
                    }
                    if (Utilitats.ComparaNumeros(valor, 0) > 0)
                        throw new Exception("'value' no s'ha repartit completament");
                }
                else if (_EsVenda)
                {
                    if (Utilitats.ComparaNumeros(value, Participacions - vParticipacionsOcupades) > 0)
                        throw new Exception("El valor no pot ser superior a 'Participacions disponibles'");

                    vParticipacionsUtilitzades = value;
                }
                else
                    throw new Exception("El moviment ha de ser una venda. Per assignar un valor a la compra sha de fer a través de 'DesgloçCompra'");
            }
        }
        private double vParticipacionsUtilitzades;


        /// <summary>
        /// Son les participacions no utilitzades en aquest moviment.
        /// </summary>
        public double _ParticipacionsDisponibles
        {
            get
            {
                if (_EsCompra)
                    return DesglosCompres.Sum(s => s._ParticipacionsDisponibles);
                if (_EsVenda)
                    return Participacions - vParticipacionsOcupades - vParticipacionsUtilitzades;

                throw new Exception("El moviment ha de ser una compra o una venda.");
            }
        }



        public double _DespesesParticipacionsDisponibles
        {
            get { return Despeses.GetValueOrDefault() / Participacions * _ParticipacionsUtilitzades; }
        }

        /// <summary>
        /// És la referéncia del la venda traspàs sobre la compra.
        /// En la BD és una relació de 0..1-->*, però hauria de ser de 0..1-->1.
        /// Per aixó només torno el primer element, que hauria de ser l'unic, si existeix.
        /// </summary>
        public Moviment _MovimentRefCompra
        {
            get { return RefTraspas1.FirstOrDefault(); }
        }

        #endregion *** Atributs ***


        #region *** Mètodes ***

        /// <summary>
        /// Calcula el preu total compra origen a partir del desgloç de les compres.
        /// </summary>
        /// <param name="calculaImportNet"></param>
        /// <param name="utilitzoParticipacionsUtilitzades"></param>
        /// <returns></returns>
        public double calculaImportCompraOrigen3(bool calculaImportNet, bool utilitzoParticipacionsUtilitzades)
        {
            double desp = 0;
            if (calculaImportNet && Despeses.HasValue)
            {
                if (utilitzoParticipacionsUtilitzades)
                    desp = Despeses.Value / Participacions * _ParticipacionsUtilitzades;
                else
                    desp = Despeses.Value;
            }

            if (_EsCompra)
            {
                double import = 0;
                foreach (DesglosCompra desglosCompra in DesglosCompres)
                {
                    double partsOrig;
                    if (!utilitzoParticipacionsUtilitzades || Utilitats.SonIguals(desglosCompra.Participacions, desglosCompra._ParticipacionsUtilitzades))
                    {
                        // Per evitar embolics amb els decimals, si Participacions i _ParticipacionsUtilitzades son iguals ja no cal dividirlos.
                        partsOrig = desglosCompra.ParticipacionsOrig;
                    }
                    else
                        // Pondero ParticipacionsOrig a partir de la diferència entre Participacions i _ParticipacionsUtilitzades.
                        partsOrig = desglosCompra.ParticipacionsOrig / desglosCompra.Participacions * desglosCompra._ParticipacionsUtilitzades;

                    import += partsOrig * desglosCompra._PreuParticipacioOrig;
                }
                return import + desp;
            }

            if (_EsVenda)
            {
                var import = compresDeLaVenda4().Sum(compra => compra.calculaImportCompraOrigen3(calculaImportNet, true));
                return import - desp;
            }

            throw new Exception(String.Format("El moviment Id:{0} no és ni compra ni venda. Tipus moviment: {1}", Id, _TipusMoviment));
        }


        /// <summary>
        /// Reseteja Participacions utilitzades i ocupades.
        /// </summary>
        /// <param name="moviments"></param>
        public static void ResetParticipacionsDeTreball(IEnumerable<Moviment> moviments)
        {
            foreach (var moviment in moviments)
                moviment.resetParticipacionsDeTreball();
        }


        /// <summary>
        /// Reseteja Participacions utilitzades i ocupades.
        /// </summary>
        internal void resetParticipacionsDeTreball()
        {
            if (_EsCompra)
                foreach (var desglosCompra in DesglosCompres)
                {
                    desglosCompra.resetParticipacionsDeTreball();
                }
            else if (_EsVenda)
            {
                vParticipacionsUtilitzades = 0;
                vParticipacionsOcupades = 0;
            }
        }

        /// <summary>
        /// Torna la llista de les vendes que utilitzen les participacions d'aquesta compra.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<Moviment> vendesDeLaCompra()
        {
            if (!_EsCompra)
                throw new ArgumentException(String.Format("El moviment ha de ser una compra. Id={0}", Id));

            var participResten = Participacions;
            var vendes1 = Prod.MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data >= Data).OrderBy(o => o.Data).ToList();

            // *** Reinicia _ParticipacionsDisponibles ***
            ResetParticipacionsDeTreball(vendes1);

            var enCarteraAbansCompra = Prod.numParticipacionsEnData(Data.AddMilliseconds(-1));
            var vendesCompra = new List<Moviment>();
            foreach (var venda in vendes1)
            {
                if (enCarteraAbansCompra > 0)
                {
                    if (Utilitats.ComparaNumeros(venda._ParticipacionsDisponibles, enCarteraAbansCompra) >= 0)
                    {
                        venda._ParticipacionsOcupades = enCarteraAbansCompra;
                        enCarteraAbansCompra = 0;
                    }
                    else
                    {
                        var partsDisp = venda._ParticipacionsDisponibles;
                        venda._ParticipacionsOcupades = partsDisp; // _ParticipacionsDisponibles quedaran a zero.
                        enCarteraAbansCompra -= partsDisp;
                        //venda._ParticipacionsDisponiblesX = 0;
                        continue;
                    }
                }

                if (Utilitats.ComparaNumeros(venda._ParticipacionsDisponibles, participResten) >= 0)
                {
                    venda._ParticipacionsUtilitzades = participResten;
                    participResten = 0;
                }
                else
                {
                    var partsDisp = venda._ParticipacionsDisponibles;
                    venda._ParticipacionsUtilitzades = partsDisp; // _ParticipacionsDisponibles quedaran a zero.
                    participResten -= partsDisp;
                }

                vendesCompra.Add(venda);
                if (participResten <= 0)
                    break;
            }

            return vendesCompra;
        }


        /// <summary>
        /// Torna la llista de les compres afectades per aquesta venda.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<Moviment> compresDeLaVenda4()
        {
            if (!_EsVenda)
                throw new ArgumentException(String.Format("El moviment ha de ser una venda. Id={0}", Id));

            return Prod.compresDeLaVenda4(Data, Participacions);
        }

        /// <summary>
        /// Torna la llista de les compres afectades per aquesta venda.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Moviment> compresDeLaVenda4Test()
        {
            return compresDeLaVenda4();
        }

        /// <summary>
        /// PiG d'una compra. !!!! MIRAR SI PUC UTILITZAR AQUEST MÈTODE PER SUBSTITUTIR LA RESTA DE CALCUL DEL PiG.
        /// </summary>
        /// <param name="ambCartera">True: Calcula vendes reals més les participacions en cartera.</param>
        /// <param name="pigOrigen">True: PiG respecte al preu de compra original. False: Pig  respecte al preu d'aquesta compra.</param>
        /// <param name="anyVenda">Si no és null només selecciona les vendes del any.</param>
        /// <param name="ambDespeses">Inclou despeses.</param>
        /// <param name="ambDividents">Inclou dividents.</param>
        /// <returns></returns>
        internal double pigDeLaCompraEsElBooooo(bool ambCartera, bool pigOrigen, uint? anyVenda, bool ambDespeses = true, bool ambDividents = true)
        {
            if (Prod is ProdFons)
            {
                // Si és un fons no té despeses ni dividents.
                ambDespeses = false;
                ambDividents = false;
            }
            if (Prod is ProdAccions)
            {
                pigOrigen = false;
            }

            double pigVendesRealsX = pigVendesReals(pigOrigen, ambDespeses, anyVenda);

            double pigEncarteraX = ambCartera ? pigEnCartera(pigOrigen, ambDespeses) : 0;
            
            double divident = ambDividents ? dividentsDeLaCompra(): 0;

            return pigVendesRealsX + pigEncarteraX + divident;
        }

        /// <summary>
        /// Torna les participacions que encara hi ha en cartera d'una compra.
        /// </summary>
        /// <returns></returns>
        private double partsEnCarteraCompra()
        {
            if (!_EsCompra)
                throw new Exception(String.Format("L'Id:{0}. Ha de ser una compra", Id));

            return Participacions - vendesDeLaCompra().Sum(s => s._ParticipacionsUtilitzades);
        }

        /// <summary>
        /// Calcula el PiG de les vendes reals de la compra.
        /// </summary>
        /// <param name="pigOrigen">Calcula el PiG respecte el valor de compra original.</param>
        /// <param name="ambDespeses">Afegeig les despeses.</param>
        /// <param name="anyVenda">Si no és null només selecciona les vendes del any.</param>
        /// <returns></returns>
        private double pigVendesReals(bool pigOrigen, bool ambDespeses, uint? anyVenda)
        {
            if (!_EsCompra)
                throw new Exception(String.Format("L'Id:{0}. Ha de ser una compra", Id));
            
            /*
             * He de comptar amb les vendes dels anys anteriors i les traspassos.
             */

            var vendesCompra = new Queue<Moviment>(vendesDeLaCompra().OrderBy(o => o.Data));
            var desgloçCompra = new Queue<DesglosCompra>(DesglosCompres.OrderBy(o => o._DataOrig));
            
            double importCostCompra = 0;
            double importVendesReals = 0;

            Moviment venda = vendesCompra.Dequeue();
            DesglosCompra desgloç = desgloçCompra.Dequeue();
            double partsVendesResten = venda._ParticipacionsUtilitzades;
            double partsDesgloçResten = desgloç.Participacions; // No utilitzo "_ParticipacionsUtilitzades"

            while (true)
            {
                if (Utilitats.EsZero(partsVendesResten))
                {
                    if (!vendesCompra.Any())
                        // No queden vendes.
                        break;
                
                    // Llegeix venda.
                    venda = vendesCompra.Dequeue();
                    partsVendesResten = venda._ParticipacionsUtilitzades;
                }

                if (Utilitats.EsZero(partsDesgloçResten))
                {
                    if(!desgloçCompra.Any())
                        // No queden desgloç.
                        break;

                    // Llegeix desgloç compra.
                    desgloç = desgloçCompra.Dequeue();
                    partsDesgloçResten = desgloç.Participacions;  // No utilitzo "_ParticipacionsUtilitzades"
                }

                if (venda.Data.Year < anyVenda.GetValueOrDefault(0) || !venda._EsVendaReal)
                {
                    // Aquesta venda no entra en el PiG del any.

                    if (Utilitats.ComparaNumeros(partsVendesResten, partsDesgloçResten) >= 0)
                    {
                        partsVendesResten -= partsDesgloçResten;
                        partsDesgloçResten = 0;
                    }
                    else
                    {
                        partsDesgloçResten -= partsVendesResten;
                        partsVendesResten = 0;
                    }
                    continue;
                }

                double parts = 0;

                if (Utilitats.ComparaNumeros(partsDesgloçResten, partsVendesResten) >= 0)
                    parts = partsVendesResten;
                else
                    parts = partsDesgloçResten;


                if (pigOrigen)
                {
                    var partsOrig = parts / desgloç.Participacions * desgloç.ParticipacionsOrig;
                    importCostCompra += partsOrig * desgloç._PreuParticipacioOrig;
                    importVendesReals += parts * venda.PreuParticipacio;
                }
                else
                {
                    importCostCompra += parts * desgloç._PreuParticipacio;
                    importVendesReals += parts * venda.PreuParticipacio;
                    if (ambDespeses)
                    {
                        var desp = parts / desgloç.Participacions * Despeses.GetValueOrDefault();
                        importCostCompra += desp;
                        desp = parts / venda.Participacions * venda.Despeses.GetValueOrDefault();
                        importVendesReals -= desp;
                    }
                }
                partsDesgloçResten -= parts;
                partsVendesResten -= parts;
            }
            
            return importVendesReals - importCostCompra;
        }

        /// <summary>
        /// PiG de les participacions en cartera de la compra amb el preu unitari actual.
        /// </summary>
        /// <param name="pigOrigen">Calcula el PiG respecte el valor de compra original.</param>
        /// <param name="ambDespeses">Afegeig les despeses.</param>
        /// <returns></returns>
        private double pigEnCartera(bool pigOrigen, bool ambDespeses)
        {
            if (!_EsCompra)
                throw new Exception(String.Format("L'Id:{0}. Ha de ser una compra", Id));

            if (Utilitats.EsZero(partsEnCarteraCompra()))
                return 0;

            double importCostCompra = 0;
            var desglosCompresOrdenat = DesglosCompres.OrderBy(o => o._DataOrig).ToList();

            var partsVenudesResten = Participacions - partsEnCarteraCompra();
            foreach (var desglosCompra in desglosCompresOrdenat)
            {
                // Calcula el cost de les participacions que queden en cartera.
                if (Utilitats.ComparaNumeros(partsVenudesResten, desglosCompra.Participacions) >= 0)
                {
                    partsVenudesResten -= desglosCompra.Participacions;
                    continue;
                }

                double parts;
                if (Utilitats.ComparaNumeros(partsVenudesResten, 0) > 0)
                {
                    parts = desglosCompra.Participacions - partsVenudesResten;
                    partsVenudesResten = 0;
                }
                else
                {
                    parts = desglosCompra.Participacions;
                }

                if (pigOrigen)
                {
                    var coeficientEnCartera = parts / desglosCompra.Participacions; // Per calcular les parts Origen que hi ha en cartera.
                    importCostCompra += desglosCompra._PreuParticipacioOrig * desglosCompra.ParticipacionsOrig * coeficientEnCartera;
                }
                else
                    importCostCompra += desglosCompra._PreuParticipacio * parts;
            }

            double importActualParticsEnCartera = partsEnCarteraCompra() * Prod._PreuParticipacioActual;

            // Despeses de la compra.
            double despeses = ambDespeses ? Despeses.GetValueOrDefault() / Participacions * partsEnCarteraCompra() : 0;

            return importActualParticsEnCartera - importCostCompra - despeses;
        }

        /// <summary>
        /// Calcula el divident que s'ha cobrat per la compra.
        /// Pot ser que hi hagi més d'un divident o que algun divident no correspongui completament a les accions de la compra.
        /// </summary>
        /// <returns></returns>
        private double dividentsDeLaCompra()
        {
            if (!_EsCompra)
                throw new Exception(String.Format("L'Id:{0}. Ha de ser una compra", Id));
            
            double divident = 0;
            var dataIni = Data;
            var dataFi = vendesDeLaCompra().Any() ? vendesDeLaCompra().Last().Data : DateTime.Now;
            var dividents = Program.Sessio.MovimentsUsuari.Where(w => w._EsDividents && w.Data >= dataIni && w.Data <= dataFi).ToList();
            foreach (var div in dividents)
            {
                var partsVenudes = vendesDeLaCompra().Where(w => w.Data < div.Data).Sum(s => s._ParticipacionsUtilitzades);
                var partsEnDataDivident = Prod.numParticipacionsEnData(div.Data);
                divident += div._ImportBrut / partsEnDataDivident * (Participacions - partsVenudes);
            }

            return divident;
        }


        /// <summary>
        /// PiG d'una compra.
        /// </summary>
        /// <param name="preuPartsEnCartera">És el preu unitari per calcular el valor de les participacions en cartera. Si null utilitza el preu actual.</param>
        /// <param name="inclouParticsEnCartera">Indica si es calcularà el valor de les participacions en cartera.</param>
        /// <returns></returns>
        private double pigDeLaCompra(double? preuPartsEnCartera = null, bool inclouParticsEnCartera = true)
        {
            if(!_EsCompra)
                throw new Exception(String.Format("Aquest moviment. Id:{0} no és una compra", Id));

            var vendesCompra = vendesDeLaCompra().ToList();

            double valorEnCartera = 0;
            if (inclouParticsEnCartera)
            {
                var partsEnCart = partsEnCarteraCompra();
                valorEnCartera = partsEnCart * preuPartsEnCartera.GetValueOrDefault(Prod._PreuParticipacioActual);
            }

            var valorVendes = vendesCompra.Sum(s => s._ParticipacionsUtilitzades * s._PreuParticipacio);

            var piG = valorEnCartera + valorVendes - _ImportBrut;

            return Math.Round(piG, 3);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal double pig2Venda()
        {
            if (!_EsVenda)
                throw new Exception("El moviment no és una venda.");

            double preuCost = 0;

            var compresAnt = this.compresDeLaVenda4().ToList();
            foreach (var compraAnt in compresAnt)
            {
                // Inclou despeses de la compra.
                preuCost += compraAnt.calculaImportCompraOrigen3(calculaImportNet: true, utilitzoParticipacionsUtilitzades: true);
            }

            // Inclou despeses de la venda.
            var pig = Participacions * PreuParticipacio - Despeses.GetValueOrDefault() - preuCost;

            return pig;
        }

        /// <summary>
        /// Al crear una nova compra, s'ha de crear el desgloç de les compres originals que li corresponen.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="vendaTraspas"></param>
        public void desgloçarCompra(InversionsBDContext connexio, Moviment vendaTraspas)
        {
            if (TipusMoviment != TipusMoviment.Compra)
                throw new ArgumentException(String.Format("El moviment ha de ser una compra. Id={0}", Id));

            if (_EsTraspas)
            {
                // ** És un traspàs.
                var compresDeLaVenda = vendaTraspas.compresDeLaVenda4().ToList();

                List<DesglosCompra> desg = new List<DesglosCompra>();
                foreach (var compra in compresDeLaVenda)
                    desg.AddRange(compra.DesglosCompres);

                //desg = desg.OrderBy(o => o._DataOrig).ToList();

                //foreach (DesglosCompra dc in desg)
                //{
                //    Debug.WriteLine("{0}\t{1}\t{2}\t{3}"
                //        , dc, dc._ParticipacionsUtilitzades.ToString(CultureInfo.CurrentCulture)
                //        , dc.Participacions.ToString(CultureInfo.CurrentCulture)
                //        , dc.ParticipacionsOrig.ToString(CultureInfo.CurrentCulture));
                //}

                var agrupatPerIdOrig = desg.OrderBy(o => o._DataOrig).GroupBy(g => g.MovCompraOrig)
                    .Select(s => new
                    {
                        movOrig = s.Key,
                        partsDesgl = s.Sum(x => x.Participacions),
                        partsUtilpDesgl = s.Sum(x => x._ParticipacionsUtilitzades),
                        partsOrigDesgl = s.Sum(x => x.ParticipacionsOrig),
                        partsUtilOrig = s.Sum(x => x._ParticipacionsUtilitzadesOrig)
                    });

                foreach (var grup in agrupatPerIdOrig)
                {
                    if (Utilitats.EsZero(grup.partsUtilpDesgl))
                        continue;

                    DesglosCompra desglosCompra = connexio.DesglosCompras.Create();

                    // ** Per obtenir parts desgloç Traspas C
                    desglosCompra.Participacions = Math.Round(grup.partsUtilpDesgl / vendaTraspas.Participacions * Participacions, 4);

                    // ** Per obtenir parts orig desgloç Traspas C
                    //desglosCompra.ParticipacionsOrig = Math.Round(grup.partsDispDesgl / grup.partsDesgl * grup.partsOrigDesgl, 4);
                    desglosCompra.ParticipacionsOrig = Math.Round(grup.partsUtilOrig, 4);

                    this.DesglosCompres.Add(desglosCompra);
                    grup.movOrig.DesglosCompresOrig.Add(desglosCompra);

                    connexio.SaveChanges();
                }
            }
            else
            {
                // ** El desgloç és una fila lligada al propi moviment.
                DesglosCompra desglosCompra = connexio.DesglosCompras.Create();

                desglosCompra.Participacions = Math.Round(this.Participacions, 4);
                desglosCompra.ParticipacionsOrig = Math.Round(this.Participacions, 4);

                //desglosCompra.RefCompraId = this.Id;
                //desglosCompra.RefCompraOrigId = this.Id;
                this.DesglosCompres.Add(desglosCompra);
                this.DesglosCompresOrig.Add(desglosCompra);

                connexio.SaveChanges();
            }
        }

        /// <summary>
        /// Calcula el preu origen de les participacions 'numParts' del moviment. Inclou despeses. 
        /// Creat el 1/07/2020
        /// </summary>
        /// <param name="numParts">Num participacions a calcular.</param>
        /// <returns></returns>
        internal double calculaPreuOrig2(double? numParts = null)
        {
            if (!_EsCompra)
                throw new Exception("El moviment no és una compra.");

            var partics = numParts.GetValueOrDefault(_ParticipacionsUtilitzades);

            if (Utilitats.ComparaNumeros(_ParticipacionsUtilitzades, partics) < 0)
                throw new ArgumentException("El valor numparts és major que les participacions disponibles.", "numParts");

            var partsUtilitzades = Participacions - _ParticipacionsUtilitzades;
            double preuOrig = 0;

            foreach (var desglosCompra in DesglosCompres)
            {
                if (partsUtilitzades >= desglosCompra.Participacions)
                {
                    partsUtilitzades -= desglosCompra.Participacions;
                    continue;
                }

                var partsPerCalcul = desglosCompra.Participacions - partsUtilitzades;
                partsUtilitzades = 0;

                if (Utilitats.ComparaNumeros(partics, partsPerCalcul) <= 0)
                {
                    partsPerCalcul = partics;
                    partics = 0;
                }
                else
                {
                    partics -= partsPerCalcul;
                }
                var despeses = Despeses.GetValueOrDefault() / Participacions * partsPerCalcul; // És la part proporcional de les despeses.
                preuOrig += desglosCompra.calculaPartsMovAPartsOrig(partsPerCalcul) * desglosCompra._PreuParticipacioOrig + despeses;
            }

            return preuOrig;
        }

        /// <summary>
        /// Crea una còpia superficial creant un objecte nou.
        /// </summary>
        /// <returns></returns>
        public Moviment ClonaCreaNouObjecte()
        {
            return (Moviment) MemberwiseClone();

            //Moviment mov = new Moviment();

            //mov.Data = Data;
            //mov.Descripcio = Descripcio;
            //mov.Despeses = Despeses;
            //mov.Id = Id;
            //mov.IdRefVenda = IdRefVenda;
            //mov.IdUsuari = IdUsuari;
            //mov.Usuari = Usuari;
            //mov.MovimentRefVenda = MovimentRefVenda;
            //mov.Participacions = Participacions;
            //mov.PreuParticipacio = PreuParticipacio;
            //mov.Prod = Prod;
            //mov.ProdId = ProdId;
            //mov.ProducteTraspas = ProducteTraspas;
            //mov.ProducteTraspasId = ProducteTraspasId;
            //mov.RowVersion = RowVersion;
            //mov.TipusMoviment = TipusMoviment;
            //mov.ValorCompraOriginal = ValorCompraOriginal;

            //return mov;
        }

        #endregion *** Mètodes ***


        #region **** Mètodes cridats des de Test *****

        public double pigDeLaCompraEsElBoooooTest(bool ambCartera, bool pigOrigen, uint? any, bool ambDespeses = true, bool ambDividents = true)
        {
            return pigDeLaCompraEsElBooooo(ambCartera, pigOrigen, any, ambDespeses, ambDividents);
        }


        public IEnumerable<Moviment> vendesDeLaCompraTest()
        {
            return vendesDeLaCompra();
        }


        public double pigDeLaCompraTest(double? preuPartsEnCartera = null, bool inclouParticsEnCartera = true)
        {
            return pigDeLaCompra(preuPartsEnCartera, inclouParticsEnCartera);
        }

        #endregion


        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Moviment a, Moviment b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null,return false.
            if ((object) a == null || (object) b == null)
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator !=(Moviment a, Moviment b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Moviment))
                return false;

            return this == (Moviment) obj;
        }

        public override string ToString()
        {
            return Id.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}
