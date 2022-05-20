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


        private IEnumerable<VendaExt> vendesDeLaCompra()
        {
            if (!_EsCompra)
                throw new ArgumentException(String.Format("El moviment ha de ser una compra. Id={0}", Id));

            List<VendaExt> vendesDeLaCompra = new List<VendaExt>();

            var partsEnCarteraAbansCompra = Prod.numParticipacionsEnData(Data.AddMilliseconds(-1)); //partsEnCarteraCompra(true, Data);
            var partsDeLaCompraResten = Participacions;
            var vendesPost = Prod.MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data > Data).OrderBy(o => o.Data).ToList();

            foreach (var venda in vendesPost)
            {
                double partsOcupades, partsUtilitzades;

                if (partsEnCarteraAbansCompra > 0)
                {
                    if (partsEnCarteraAbansCompra >= venda.Participacions)
                    {
                        partsEnCarteraAbansCompra -= venda.Participacions;
                        continue;
                    }

                    partsOcupades = partsEnCarteraAbansCompra;
                    double partsDisponibles = venda.Participacions - partsOcupades;
                    partsUtilitzades = partsDisponibles >= partsDeLaCompraResten ? partsDeLaCompraResten : partsDisponibles;

                    partsDeLaCompraResten -= partsUtilitzades;
                    partsEnCarteraAbansCompra = 0;
                }
                else
                {
                    partsOcupades = 0;

                    if (venda.Participacions >= partsDeLaCompraResten)
                    {
                        partsUtilitzades = partsDeLaCompraResten;
                        partsDeLaCompraResten = 0;
                    }
                    else
                    {
                        partsUtilitzades = venda.Participacions;
                        partsDeLaCompraResten -= venda.Participacions;
                    }
                }

                vendesDeLaCompra.Add(new VendaExt(venda, partsOcupades, partsUtilitzades));

                if (Utilitats.EsZero(partsDeLaCompraResten))
                   break;
            }

            return vendesDeLaCompra;
        }


        /// <summary>
        /// Torna la llista de les compres afectades per aquesta venda.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<CompraExt> compresDeLaVenda4()
        {
            if (!_EsVenda)
                throw new ArgumentException(String.Format("El moviment ha de ser una venda. Id={0}", Id));

            return Prod.compresDePartipacionsEnData(Data, Participacions);
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
        /// Torna les participacions que encara hi ha en cartera d'una compra a 'dataHora'.
        /// </summary>
        /// <param name="dataHora">Vendes amb data menor o igual a dataHora. Si null, totes les vendes.</param>
        /// <returns></returns>
        private double partsEnCarteraCompra(DateTime? dataHora = null)
        {
            if (!_EsCompra)
                throw new Exception(String.Format("L'Id:{0}. Ha de ser una compra", Id));

            var dataH = dataHora.GetValueOrDefault(DateTime.Now);

            if (dataH < Data)
                return 0;

            // Suma de les participacions comprades incloses les d'aquesta compra.
            var partsC = Program.Sessio.MovimentsUsuari.Where(w => w.Prod == Prod && w._EsCompra && w.Data <= Data).Sum(s => s.Participacions);

            // Suma de les participacions venudes amb data <= 'dataH'
            var partsV = Program.Sessio.MovimentsUsuari.Where(w => w.Prod == Prod && w._EsVenda && w.Data <= dataH).Sum(s => s.Participacions);

            var partsComprades = partsC - partsV;

            // Si partsComprades >= Participacions. Encara no s'ha venut cap participació.
            // Si partsComprades < Participacions i partsComprades > 0. Encara falten per vendre 'partsComprades'.
            // Si partsComprades < Participacions i partsComprades <= 0. S'ha venut tot.
            return partsComprades >= Participacions ? Participacions : (partsComprades > 0 ? partsComprades : 0);
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

            var vendesCompra = new Queue<VendaExt>(vendesDeLaCompra().OrderBy(o => o._Data));
            if (!vendesCompra.Any())
                return 0;

            var desgloçCompra = new Queue<DesglosCompra>(DesglosCompres.OrderBy(o => o._DataOrig));
            
            double importCostCompra = 0;
            double importVendesReals = 0;

            VendaExt venda = vendesCompra.Dequeue();
            DesglosCompra desgloç = desgloçCompra.Dequeue();
            double partsVendesResten = venda._PartsUtilitzades;
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
                    partsVendesResten = venda._PartsUtilitzades;
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

                if (venda._Data.Year < anyVenda.GetValueOrDefault(0) || !venda._EsVendaReal)
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

                parts = Utilitats.ComparaNumeros(partsDesgloçResten, partsVendesResten) >= 0 ? partsVendesResten : partsDesgloçResten;

                if (pigOrigen)
                {
                    var partsOrig = parts / desgloç.Participacions * desgloç.ParticipacionsOrig;
                    importCostCompra += partsOrig * desgloç._PreuParticipacioOrig;
                    importVendesReals += parts * venda._PreuParticipacio;
                }
                else
                {
                    importCostCompra += parts * desgloç._PreuParticipacio;
                    importVendesReals += parts * venda._PreuParticipacio;
                    if (ambDespeses)
                    {
                        var desp = parts / desgloç.Participacions * Despeses.GetValueOrDefault();
                        importCostCompra += desp;
                        desp = parts / venda._Participacions * venda._Despeses;
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
        internal double pigEnCartera(bool pigOrigen, bool ambDespeses)
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
            var dataFi = vendesDeLaCompra().Any() ? vendesDeLaCompra().Last()._Data : DateTime.Now;
            var dividents = Program.Sessio.MovimentsUsuari.Where(w => w._EsDividents && w.Data >= dataIni && w.Data <= dataFi).ToList();
            foreach (var div in dividents)
            {
                var partsVenudes = vendesDeLaCompra().Where(w => w._Data < div.Data).Sum(s => s._PartsUtilitzades);
                var partsEnDataDivident = Prod.numParticipacionsEnData(div.Data);
                divident += div._ImportBrut / partsEnDataDivident * (Participacions - partsVenudes);
            }

            return divident;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal double pig2Venda(bool inclouDespeses)
        {
            if (!_EsVenda)
                throw new Exception("El moviment no és una venda.");

            double preuCost = 0;

            var compresAnt = this.compresDeLaVenda4().ToList();
            foreach (var compraAnt in compresAnt)
            {
                // Inclou despeses de la compra.
                preuCost += compraAnt.calculaImportCompraOrigen3(calculaImportNet: inclouDespeses, utilitzoParticipacionsUtilitzades: true);
            }

            // Inclou despeses de la venda.
            var despeses = inclouDespeses ? Despeses.GetValueOrDefault() : 0;
            var pig = Participacions * PreuParticipacio - despeses - preuCost;

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

                var desgloçCompresVenda = vendaTraspas.Prod.desglosCompresDeParticipacionsEnData(vendaTraspas.Data, vendaTraspas.Participacions).ToList();

                var agrupatPerIdOrig = desgloçCompresVenda.OrderBy(o => o._DataOrig).GroupBy(g => g._CompraOrig)
                    .Select(s => new
                    {
                        movOrig = s.Key,
                        sumPartsUtil = s.Sum(x => x._PartsUtilitzades),
                        sumPartsUtilOrig = s.Sum(x => x._PartsUtilitzadesOrig)
                    });

                foreach (var grup in agrupatPerIdOrig)
                {
                    if (Utilitats.EsZero(grup.sumPartsUtil))
                        continue;

                    DesglosCompra desglosCompra = connexio.DesglosCompras.Create();

                    // ** Per obtenir parts desgloç Traspas C
                    desglosCompra.Participacions = Math.Round(grup.sumPartsUtil / vendaTraspas.Participacions * Participacions, 4);

                    // ** Per obtenir parts orig desgloç Traspas C
                    desglosCompra.ParticipacionsOrig = Math.Round(grup.sumPartsUtilOrig, 4);

                    DesglosCompres.Add(desglosCompra);
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

                DesglosCompres.Add(desglosCompra);
                DesglosCompresOrig.Add(desglosCompra);

                connexio.SaveChanges();
            }
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


        public IEnumerable<VendaExt> vendesDeLaCompraTest()
        {
            return vendesDeLaCompra();
        }


        public double pig2VendaTest(bool inclouDespeses)
        {
            return pig2Venda(inclouDespeses);
        }


        public double dividentsDeLaCompraTest()
        {
            return dividentsDeLaCompra();
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
