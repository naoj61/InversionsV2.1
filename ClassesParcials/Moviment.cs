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
        
        /// <summary>
        /// Calcula el preu compra unitari origen a partir del _ImportCompraOrigen.
        /// Aquest import multiplicat per les participacions del moviment actual ha de donar el preu de cost total.
        /// </summary>
        public double _PreuCompraParticipacioOrigen
        {
            get { return calculaImportCompraOrigen3(calculaImportNet: false, utilitzoParticipacionsDisponibles: false) / Participacions; }
        }


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
            get { return RefTraspasN != null ? RefTraspasN.Prod : null; }
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
            get { return RefTraspasN != null; }
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
        /// L'utilitzo per saber les participacions disponibles que poden no ser les mateixes que les del moviment.
        /// </summary>
        public double _ParticipacionsDisponibles
        {
            get
            {
                if (_EsCompra)
                    return DesglosCompres.Sum(s => s._ParticipacionsDisponibles);
                if (_EsVenda)
                    return vParticipacionsDisponiblesVenda.GetValueOrDefault(Participacions);

                throw new Exception("El moviment ha de ser una compra o una venda.");
            }
            set
            {
                if (!_EsVenda)
                    throw new Exception("El moviment ha de ser una venda. Per assignar un valor a la compra sha de fer a través de 'DesgloçCompra'");

                if (value > Participacions)
                    throw new Exception("El valor no pot ser superior a 'Participacions'");

                vParticipacionsDisponiblesVenda = value;
            }
        }
        private double? vParticipacionsDisponiblesVenda;


        public double _DespesesParticipacionsDisponibles
        {
            get { return Despeses.GetValueOrDefault() / Participacions * _ParticipacionsDisponibles; }
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
        /// <param name="utilitzoParticipacionsDisponibles"></param>
        /// <returns></returns>
        public double calculaImportCompraOrigen3(bool calculaImportNet, bool utilitzoParticipacionsDisponibles)
        {
            double desp = 0;
            if (calculaImportNet && Despeses.HasValue)
            {
                if (utilitzoParticipacionsDisponibles)
                    desp = Despeses.Value / Participacions * _ParticipacionsDisponibles;
                else
                    desp = Despeses.Value;
            }

            if (_EsCompra)
            {
                double import = 0;
                foreach (DesglosCompra desglosCompra in DesglosCompres)
                {
                    double partsOrig;
                    if (!utilitzoParticipacionsDisponibles || Utilitats.SonIguals(desglosCompra.Participacions, desglosCompra._ParticipacionsDisponibles))
                    {
                        // Per evitar embolics amb els decimals, si Participacions i _ParticipacionsDisponibles son iguals ja no cal dividirlos.
                        partsOrig = desglosCompra.ParticipacionsOrig;
                    }
                    else
                        // Pondero ParticipacionsOrig a partir de la diferència entre Participacions i _ParticipacionsDisponibles.
                        partsOrig = desglosCompra.ParticipacionsOrig / desglosCompra.Participacions * desglosCompra._ParticipacionsDisponibles;

                    import += partsOrig * desglosCompra._PreuParticipacioOrig;
                }
                return import + desp;
            }

            if (_EsVenda)
            {
                var import = compresDeLaVenda3().Sum(compra => compra.calculaImportCompraOrigen3(calculaImportNet, true));
                return import - desp;
            }

            throw new Exception(String.Format("El moviment Id:{0} no és ni compra ni venda. Tipus moviment: {1}", Id, _TipusMoviment));
        }


        /// <summary>
        /// Reseteja el valor de vParticipacionsDisponibles dels moviments del producte.
        /// </summary>
        /// <param name="producte"></param>
        internal static void ResetParticipacionsDisponibles(Producte producte)
        {
            ResetParticipacionsDisponibles(producte.MovimentsProducteUsuari.Where(w=>w.TipusMoviment == TipusMoviment.Compra));
        }


        /// <summary>
        /// Reseteja el valor de vParticipacionsDisponibles dels moviments del paràmetre.
        /// </summary>
        /// <param name="moviments">Llista de moviments a resetejar.</param>
        internal static void ResetParticipacionsDisponibles(IEnumerable<Moviment> moviments)
        {
            foreach (var moviment in moviments)
            {
                if (moviment._EsCompra)
                    DesglosCompra.ResetParticipacionsDisponibles(moviment.DesglosCompres);
                else if (moviment._EsVenda)
                    moviment.vParticipacionsDisponiblesVenda = null;
            }
        }

        public IEnumerable<Moviment> vendesDeLaCompraTest(out double participEnCartera)
        {
            return vendesDeLaCompra(out participEnCartera);
        }

        /// <summary>
        /// Torna la llista de les vendes que utilitzen les participacions d'aquesta compra
        /// </summary>
        /// <param name="participEnCartera">Son les participacions que no s'han venut.</param>
        /// <returns></returns>
        private IEnumerable<Moviment> vendesDeLaCompra(out double participEnCartera)
        {
            if (!_EsCompra)
                throw new ArgumentException(String.Format("El moviment ha de ser una compra. Id={0}", Id));

            participEnCartera = Participacions;
            var vendes1 = Prod.MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data >= Data).OrderBy(o => o.Data).ToList();

            // *** Reinicia _ParticipacionsDisponibles ***
            ResetParticipacionsDisponibles(vendes1);

            var enCarteraAbansCompra = Prod.numParticipacionsEnData(Data.AddMilliseconds(-1));
            var vendesCompra = new List<Moviment>();
            foreach (var venda in vendes1)
            {
                if (enCarteraAbansCompra > 0)
                {
                    venda._ParticipacionsDisponibles -= enCarteraAbansCompra;
                    enCarteraAbansCompra -= venda.Participacions;
                    if (venda._ParticipacionsDisponibles <= 0)
                        continue;
                }

                if (participEnCartera < venda._ParticipacionsDisponibles)
                    venda._ParticipacionsDisponibles = participEnCartera;

                vendesCompra.Add(venda);
                participEnCartera -= venda._ParticipacionsDisponibles;
                if (participEnCartera <= 0)
                    break;
            }
            return vendesCompra;
        }

        /// <summary>
        /// Torna la llista de les compres a les que afecten aquesta venda.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<Moviment> compresDeLaVenda3()
        {
            if (!_EsVenda)
                throw new ArgumentException(String.Format("El moviment ha de ser una venda. Id={0}", Id));

            return Prod.compresAnteriors3(Data, Participacions);
        }

        public IEnumerable<Moviment> compresDeLaVenda3Test()
        {
            return compresDeLaVenda3();
        }



        public double trobaParticipacionsDisponiblesDesgloçCompraTest(double partsUtilitzadesAbans, double partVenudesRestants)
        {
            return trobaParticipacionsDisponiblesDesgloçCompra(partsUtilitzadesAbans, partVenudesRestants);
        }

        /// <summary>
        /// Assigna al desgloç les participacions venudes.
        /// </summary>
        /// <param name="partsUtilitzadesAbans">Son les participacions assignades a una venda anterior.</param>
        /// <param name="partVenudesRestants">Son les participacions venudes que encara no se'ls ha assignat compra.</param>
        /// <returns>Son les participacions que no s'han pogut assignar.</returns>
        internal double trobaParticipacionsDisponiblesDesgloçCompra(double partsUtilitzadesAbans, double partVenudesRestants)
        {
            if(Utilitats.ComparaNumeros(partsUtilitzadesAbans, Participacions) > 0)
                throw new Exception("El valor de 'partsUtilitzadesAbans' és superior al total particions de la compra");

            Queue<DesglosCompra> desgCompres = new Queue<DesglosCompra>(DesglosCompres.OrderBy(o => o._DataOrig));

            if (!desgCompres.Any())
                throw new Exception(String.Format("La compra Id:{0}, no te cap fila a la taula 'DesglosCompra'", Id));

            DesglosCompra desgCompra = null;
        
            // *** Aquí tracto les participacions utilitzades en una venda anterior.
            while (desgCompres.Any())
            {
                desgCompra = desgCompres.Dequeue();

                if (Utilitats.ComparaNumeros(partsUtilitzadesAbans, desgCompra._ParticipacionsDisponibles) > 0)
                {
                    // * Desgloç utilitzat totalment.
                    partsUtilitzadesAbans -= desgCompra._ParticipacionsDisponibles;
                    desgCompra._ParticipacionsDisponibles = 0;
                    continue; // * Desgloç utilitzat totalment, vaig a pel següent..
                }
             
                // * Desgloç utilitzat parcialment, ja no hi ha més partsUtilitzadesAbans, acabo aquesta part.
                desgCompra._ParticipacionsDisponibles -= partsUtilitzadesAbans;
                break;
            }
            

            // *** Aquí tracto les participacions utilitzades en aquesta venda.
            while (desgCompra != null)
            {
                if (Utilitats.EsZero(partVenudesRestants))
                    // ** Ja no queden parts venudes, poso _ParticipacionsDisponibles a zero.
                    desgCompra._ParticipacionsDisponibles = 0;
                else if (Utilitats.ComparaNumeros(partVenudesRestants, desgCompra._ParticipacionsDisponibles) > 0)
                {
                    // ** Deixo totes les _ParticipacionsDisponibles 
                    partVenudesRestants -= desgCompra._ParticipacionsDisponibles;
                }
                else
                {
                    // ** Les _ParticipacionsDisponibles son la resta de partVenudesRestants que queden.
                    desgCompra._ParticipacionsDisponibles = partVenudesRestants;
                    partVenudesRestants = 0;
                }

                if (!desgCompres.Any())
                    break;

                desgCompra = desgCompres.Dequeue();
            }

            return partVenudesRestants;
        }

        
        public double pigDeLaCompraTest(double? preuPartsEnCartera = null, bool inclouParticsEnCartera = true)
        {
            return pigDeLaCompra(preuPartsEnCartera, inclouParticsEnCartera);
        }

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
        internal double pigDeLaCompra(double? preuPartsEnCartera = null, bool inclouParticsEnCartera = true)
        {
            if(!_EsCompra)
                throw new Exception(String.Format("Aquest moviment. Id:{0} no és una compra", Id));

            double participEnCartera;

            var vendesCompra = vendesDeLaCompra(out participEnCartera);

            double valorEnCartera = 0;
            if (inclouParticsEnCartera)
                valorEnCartera = participEnCartera * preuPartsEnCartera.GetValueOrDefault(Prod.valorParticipacio());

            var valorVendes = vendesCompra.Sum(s => s._ParticipacionsDisponibles * s._PreuParticipacio);

            var piG = -ImportBrut + valorEnCartera + valorVendes;

            return Math.Round(piG, 3);
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

            if (_EsCompraReal)
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
            else
            {
                // ** És un traspàs.
                var cAnt = vendaTraspas.compresDeLaVenda3().ToList();

                var partsTotDsipCompresAnt = cAnt.Sum(s => s._ParticipacionsDisponibles);
                var partsTotCompra = Participacions;

                List<DesglosCompra> desg = new List<DesglosCompra>();
                foreach (var compra in cAnt)
                    desg.AddRange(compra.DesglosCompres);

                desg = desg.OrderBy(o => o._DataOrig).ToList();

                foreach (DesglosCompra dc in desg)
                {
                    Debug.WriteLine("{0}\t{1}\t{2}\t{3}"
                        , dc, dc._ParticipacionsDisponibles.ToString(CultureInfo.CurrentCulture), dc.Participacions.ToString(CultureInfo.CurrentCulture), dc.ParticipacionsOrig.ToString(CultureInfo.CurrentCulture));
                }

                var agrupatPerIdOrig = desg.OrderBy(o=>o._DataOrig).GroupBy(g => g.MovCompraOrig)
                    .Select(s => new
                    {
                        movOrig = s.Key,
                        partsDesgl = s.Sum(x => x.Participacions),
                        partsDispDesgl = s.Sum(x => x._ParticipacionsDisponibles),
                        partsOrigDesgl = s.Sum(x => x.ParticipacionsOrig)
                        ,
                        partsOrigDisp = s.Sum(x => x.ParticipacionsOrig / x.Participacions * x._ParticipacionsDisponibles)
                    });

                foreach (var grup in agrupatPerIdOrig)
                {
                    if (Utilitats.EsZero(grup.partsDispDesgl))
                        continue;

                    DesglosCompra desglosCompra = connexio.DesglosCompras.Create();

                    // ** Per obtenir parts desgloç Traspas C
                    desglosCompra.Participacions = Math.Round(grup.partsDispDesgl / partsTotDsipCompresAnt * partsTotCompra, 4);

                    // ** Per obtenir parts orig desgloç Traspas C
                    //desglosCompra.ParticipacionsOrig = Math.Round(grup.partsDispDesgl / grup.partsDesgl * grup.partsOrigDesgl, 4);
                    desglosCompra.ParticipacionsOrig = Math.Round(grup.partsOrigDisp, 4);

                    this.DesglosCompres.Add(desglosCompra);
                    grup.movOrig.DesglosCompresOrig.Add(desglosCompra);

                    connexio.SaveChanges();
                }
            }
        }


        public double ImportBrut
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

        public double ImportNet
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
