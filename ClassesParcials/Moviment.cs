using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Comuns;

namespace Inversions
{

    /// <summary>
    /// El moviment de compra lligadas a una venda pot ser que no utilitzi totes les participacions.
    /// </summary>
    public struct MovimentCompra
    {
        public MovimentCompra(Moviment moviment, double participacionsDisponibles)
            : this()
        {
            if (!moviment._EsCompra)
                throw new ArgumentException("El moviment ha de ser una compra.", "moviment");

            _Moviment = moviment;
            _ParticipacionsDisponibles = participacionsDisponibles;
        }

        /// <summary>
        /// Son les participacions que s'estan venent del total.
        /// </summary>
        public double _ParticipacionsDisponibles { get; private set; }

        public Moviment _Moviment { get; private set; }

        public Moviment _MovimentRefVenda
        {
            get { return _Moviment.MovimentRefVendaN; }
        }

        [Obsolete("Obsolet. No utilitzar el camp 'PreuParticipacioOrigen'")]
        public double _PreuParticipacioOrigen
        {
            get { return _Moviment.PreuParticipacioOrigen.GetValueOrDefault(_Moviment.PreuParticipacio); }
        }

        public bool _EsTraspas
        {
            get { return _Moviment._EsTraspas; }
        }

        /// <summary>
        /// Indica que estem venent totes les participacions d'aquesta compra.
        /// </summary>
        public bool _EsVendaTotal
        {
            get { return Utilitats.SonIguals(_ParticipacionsDisponibles, _Moviment.Participacions); }
        }

        public override string ToString()
        {
            return _Moviment.Id.ToString(CultureInfo.InvariantCulture);
        }
    }


    /// <summary>
    /// El desgloç del moviment de compra lligadas a una venda pot ser que no utilitzi totes les participacions.
    /// </summary>
    public struct MovimentDesglosCompra
    {
        public DesglosCompra _DesglosCompra { get; private set; }
        public double _ParticipacionsDelMoviment { get; private set; }
        public double _ParticipacionsDelMovimentOrigen { get; private set; }

        public MovimentDesglosCompra(DesglosCompra desglosCompra, double participacionsDelMoviment, double participacionsDelMovimentOrig)
            : this()
        {
            _DesglosCompra = desglosCompra;
            _ParticipacionsDelMoviment = participacionsDelMoviment;
            _ParticipacionsDelMovimentOrigen = participacionsDelMovimentOrig;
        }

        public MovimentDesglosCompra(DesglosCompra desglosCompra, double participacionsDelMoviment)
            : this(desglosCompra, participacionsDelMoviment
                , participacionsDelMoviment / desglosCompra.Participacions * desglosCompra.ParticipacionsOrig)
        {}


        public DateTime _DataOrig
        {
            get { return _DesglosCompra.RefCompraOrig.Data; }
        }

        public double _PreuParticipacioOrig
        {
            get { return _DesglosCompra._PreuPartOrig; }
        }


        public override string ToString()
        {
            return String.Format("Id={0}. MovId={1}. MovOrigId={2}", _DesglosCompra.Id, _DesglosCompra.RefCompra.Id, _DesglosCompra.RefCompraOrigId);
        }
    }


    public partial class Moviment
    {
        #region *** Atributs ***
                     
        //public string _NomProducteTraspasOrigen
        //{
        //    get { return _ProducteTraspasOrigen != null ? _ProducteTraspasOrigen._NomProducte : null; }
        //}

        //public string _NomProducteTraspasDesti
        //{
        //    get { return _ProducteTraspasDesti != null ? _ProducteTraspasDesti._NomProducte : null; }
        //}

        public Producte _ProducteTraspasOrigen
        {
            get { return TipusMoviment == TipusMoviment.Compra ? _ProducteTraspas : null; }
        }

        public Producte _ProducteTraspasDesti
        {
            get { return TipusMoviment == TipusMoviment.Venda ? _ProducteTraspas : null; }
        }

        public Producte _ProducteTraspas
        {
            get { return MovimentRefVendaN != null ? MovimentRefVendaN.Prod : null; }
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
            get { return MovimentRefVenda1.Any(); }
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
            get { return MovimentRefVenda1.FirstOrDefault(); }
        }

        #endregion *** Atributs ***


        #region *** Test ***

        public IEnumerable<MovimentDesglosCompra> TestCompresDeLaVenda(InversionsBDContext connexio)
        {
            return compresDeLaVenda(connexio);
        }

        #endregion *** Test ***


        #region *** Mètodes ***

        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" de la venda del paràmetre.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MovimentCompra> compresAnteriors()
        {
            if (TipusMoviment != TipusMoviment.Venda)
                throw new ArgumentException("El moviment ha de ser una venda.", "venda");

            return Prod.compresAnteriors(Data, Participacions);
        }


        /// <summary>
        /// Al crear una nova compra, s'ha de crear el desgloç de les compres originals que li corresponen.
        /// </summary>
        /// <param name="connexio"></param>
        public void desgloçarCompra(InversionsBDContext connexio)
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

                // ** Troba les compres de la venda lligada al traspàs.
                var compresAnt = MovimentRefVendaN.compresDeLaVenda(connexio).OrderBy(o => o._DataOrig).ToList();
                
                // ** Agrupa les compres pel id orig.
                var agrupatPerIdOrig = compresAnt.GroupBy(g => g._DesglosCompra.RefCompraOrigId)
                    .Select(s => new
                    {
                        Id = s, partDelMoviment = s.Sum(x => x._ParticipacionsDelMoviment)
                        , partDelMovimentOrig = s.Sum(x => x._ParticipacionsDelMovimentOrigen)
                    });

                foreach (var grup in agrupatPerIdOrig)
                {
                    var movOrig = grup.Id.ElementAt(0)._DesglosCompra.RefCompraOrig;

                    DesglosCompra desglosCompra = connexio.DesglosCompras.Create();

                    desglosCompra.Participacions = Math.Round(Participacions / MovimentRefVendaN.Participacions * grup.partDelMoviment, 4);
                    desglosCompra.ParticipacionsOrig = Math.Round(grup.partDelMovimentOrig, 4);

                    //desglosCompra.RefCompraId = this.Id;
                    //desglosCompra.RefCompraOrigId = compraOrig.RefCompraOrigId;
                    this.DesglosCompres.Add(desglosCompra);
                    movOrig.DesglosCompresOrig.Add(desglosCompra);

                    connexio.SaveChanges();
                }                
            }
        }


        /// <summary>
        /// Troba les compres i les participacions afectades per la venda. Inclou les participacions originals.
        /// </summary>
        /// <param name="connexio"></param>
        /// <returns></returns>
        internal IEnumerable<MovimentDesglosCompra> compresDeLaVenda(InversionsBDContext connexio)
        {
            if (TipusMoviment != TipusMoviment.Venda)
                throw new ArgumentException(String.Format("El moviment ha de ser una venda. Id={0}", Id));

            // ** Troba les vendes anteriors.
            var vendesAnt = new List<Moviment>(connexio.Moviments
                .Where(w => w.UsuariId == UsuariId && w.ProdId == ProdId && w.TipusMoviment == TipusMoviment.Venda && w.Data < Data)
                .OrderBy(o => o.Data));

            // ** Troba les compres desgloçades anteriors i les ordena per data moviment i data origen.
            /* 
             * Si hi ha vendes anteriors a l'actual, per trobar les compres corresponents, aquestes s'han
             * d'ordenar per data moviment+data origen, un cop descomptades aquestes compres, les restants 
             * s'ordenaran per data origen.
             */
            Queue<DesglosCompra> compresDesgAnt = new Queue<DesglosCompra>(connexio.DesglosCompras
                .Where(w => w.RefCompra.UsuariId == UsuariId && w.RefCompra.ProdId == ProdId && w.RefCompra.Data < Data)
                .OrderBy(o => o.RefCompra.Data).ThenBy(o => o.RefCompraOrig.Data));

            double partsQuedenDeLaUltimaCompra = 0;
            DesglosCompra ultimaCompra = null;

            // ** Resta de les compres anteriors les participacions venudes en les vendes anteriors.
            foreach (var venda in vendesAnt)
            {
                double partsQuedenDeLaVenda = venda.Participacions;

                while (compresDesgAnt.Count > 0 && partsQuedenDeLaVenda > 0)
                {
                    if (Utilitats.EsZero(partsQuedenDeLaUltimaCompra))
                    {
                        ultimaCompra = compresDesgAnt.Dequeue();
                        partsQuedenDeLaUltimaCompra = ultimaCompra.Participacions;
                    }

                    if (partsQuedenDeLaVenda >= partsQuedenDeLaUltimaCompra)
                    {
                        partsQuedenDeLaVenda -= partsQuedenDeLaUltimaCompra;
                        partsQuedenDeLaUltimaCompra = 0;
                    }
                    else
                    {
                        partsQuedenDeLaUltimaCompra -= partsQuedenDeLaVenda;
                        partsQuedenDeLaVenda = 0;
                    }
                }
            }

            
            // **** Troba les compres i les participacions que corresponen a la venda.

            List<MovimentDesglosCompra> compresDeLaVendaDesg = new List<MovimentDesglosCompra>();

            if (ultimaCompra != null && partsQuedenDeLaUltimaCompra > 0)
                // ** Remanent dela última compra anterior.
                compresDeLaVendaDesg.Add(new MovimentDesglosCompra(ultimaCompra, partsQuedenDeLaUltimaCompra));

            // ** Ordeno les compres restants per data Origen.
            compresDesgAnt = new Queue<DesglosCompra>(compresDesgAnt.OrderBy(o => o.RefCompraOrig.Data));

            double partsQuedenDeLaVenda2 = Participacions - partsQuedenDeLaUltimaCompra;
            while (compresDesgAnt.Count > 0 && partsQuedenDeLaVenda2 > 0)
            {
                ultimaCompra = compresDesgAnt.Dequeue();

                if (partsQuedenDeLaVenda2 >= ultimaCompra.Participacions)
                {
                    partsQuedenDeLaVenda2 -= ultimaCompra.Participacions;
                    compresDeLaVendaDesg.Add(new MovimentDesglosCompra(ultimaCompra, ultimaCompra.Participacions, ultimaCompra.ParticipacionsOrig));
                }
                else
                {
                    compresDeLaVendaDesg.Add(new MovimentDesglosCompra(ultimaCompra, partsQuedenDeLaVenda2));
                    partsQuedenDeLaVenda2 = 0;
                }
            }

            return compresDeLaVendaDesg;
        }


        /// <summary>
        /// Calcula el preu de compra origen d'un moviment de; Compra, venda o traspàs.
        /// </summary>
        /// <returns></returns>
        [ObsoleteAttribute("Obsolet. El manting perquè encara desa el camp 'PreuParticipacioOrigen' malgrat no l'utilitzo")]
        internal double calculaPreuOrigen()
        {
            double valorRetorn;

            if (TipusMoviment == TipusMoviment.Compra)
            {
                if (MovimentRefVendaN == null)
                {
                    valorRetorn = PreuParticipacio;
                }
                else
                {
                    if (MovimentRefVendaN.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'movimentVendaVinculatCompra' és NULL i hauria de tenir algún valor.");

                    valorRetorn = MovimentRefVendaN.PreuParticipacioOrigen.Value * MovimentRefVendaN.Participacions / Participacions;
                }
            }
            else if (TipusMoviment == TipusMoviment.Venda || TipusMoviment == TipusMoviment.Traspàs)
            {
                double x = 0;
                double y = 0;

                foreach (var compra in compresAnteriors())
                {
                    if (compra._Moviment.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'compra._Moviment.PreuParticipacioOrigen' és NULL i hauria de tenir algún valor. Id moviment: " + compra._Moviment.Id);

                    x += compra._ParticipacionsDisponibles * compra._Moviment.PreuParticipacioOrigen.Value;
                    y += compra._ParticipacionsDisponibles;
                }
                valorRetorn = x / y;
            }
            else
            {
                throw new ApplicationException("El moviment ha de ser: Compra, venda o traspàs.");
            }

            return Math.Round(valorRetorn, 4);
        }

        public double ImportBrut
        {
            get
            {
                double result;
                if (Program.EsZero(Participacions))
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
                if (Program.EsZero(Participacions))
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

        public Moviment Clone()
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
