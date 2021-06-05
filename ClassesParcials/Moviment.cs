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

        public Producte _ProducteTraspas
        {
            get { return RefTraspas != null ? RefTraspas.Prod : null; }
        }

        /// <summary>
        /// Torna tipus movimen en string i indica els traspassos.
        /// </summary>
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
        /// Torna la llista de les vendes que utilitzen les participacions d'aquesta compra
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
        /// Torna les participacions que encara hi ha en cartera de una compra real. No serveix per compres traspassos.
        /// La compra ha de pertanyer a un fons d'inversió.
        /// </summary>
        /// <returns></returns>
        public double partsEnCarteraCompra()
        {
            return DesglosCompra.PartsEnCarteraCompra(this);
        }

        [Description("S'utilitza en un DataGrid")]
        public double _PigDeLaCompra
        {
            get { return pigDeLaCompra(); }
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
                var partsEnCart = Participacions - vendesCompra.Sum(s => s._ParticipacionsUtilitzades);
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
        /// Calcula el preu origen de les partticipacions 'numParts' del moviment. Inclou despeses. 
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
