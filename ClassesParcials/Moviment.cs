using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Comuns;

namespace Inversions
{
    public partial class Moviment
    {

        internal struct MovimentCompra
        {
            public Moviment _Moviment { get; private set; }
            public double _ParticipacionsDisponibles { get; set; }
            public bool _EsCompraReal
            {
                get { return _Moviment._EsCompraReal; }
            }

            public MovimentCompra(Moviment moviment, double participacionsDisponibles)
                : this()
            {
                _Moviment = moviment;
                _ParticipacionsDisponibles = participacionsDisponibles;
            }
        }

        #region *** Atributs ***

        public string _NomProducteTraspasOrigen
        {
            get { return _ProducteTraspasOrigen != null ? _ProducteTraspasOrigen._NomProducte : null; }
        }

        public string _NomProducteTraspasDesti
        {
            get { return _ProducteTraspasDesti != null ? _ProducteTraspasDesti._NomProducte : null; }
        }

        public Producte _ProducteTraspasOrigen
        {
            get { return TipusMoviment == TipusMoviment.Compra ? ProducteTraspas : null; }
        }


        public Producte _ProducteTraspasDesti
        {
            get { return TipusMoviment == TipusMoviment.Venda ? ProducteTraspas : null; }
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
            get
            {
                return ProducteTraspas != null;
            }
        }

        /// <summary>
        /// Pot ser compra o traspas compra.
        /// </summary>
        public bool _EsCompra
        {
            get
            {
                return TipusMoviment == TipusMoviment.Compra;
            }
        }

        /// <summary>
        /// Compra. No traspàs.
        /// </summary>
        public bool _EsCompraReal
        {
            get
            {
                return _EsCompra && !_EsTraspas;
            }
        }

        /// <summary>
        /// Pot ser venda o traspàs venda.
        /// </summary>
        public bool _EsVenda
        {
            get
            {
                return TipusMoviment == TipusMoviment.Venda;
            }
        }

        /// <summary>
        /// Venda. no traspàs
        /// </summary>
        public bool _EsVendaReal
        {
            get
            {
                return _EsVenda && !_EsTraspas;
            }
        }

        public bool _EsDividents
        {
            get
            {
                return TipusMoviment == TipusMoviment.Dividends;
            }
        }

        public double _PreuParticipacio
        {
            get
            {
                return PreuParticipacio;
            }
        }

        /// <summary>
        /// És la referéncia del la venda traspàs sobre la compra.
        /// En la BD és una relació de 0..1-->*, però hauria de ser de 0..1-->1.
        /// Per aixó només torno el primer element, que hauria de ser l'unic, si existeix.
        /// </summary>
        public Moviment _MovimentRefCompra
        {
            get { return NoUtilitzar1.FirstOrDefault(); }
        }

        #endregion *** Atributs ***
        
        #region *** Mètodes ***

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
            return (Moviment)MemberwiseClone();

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



        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora, fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="numParticipacions">Numero de participacions que es volen vendre. Si null, totes.</param>
        /// <returns></returns>
        private IEnumerable<MovimentCompra> compresAnteriors(double? numParticipacions = null)
        {
            DateTime dataHora = Data;
            double particAVendre = numParticipacions.HasValue ? numParticipacions.Value : Prod.numParticipacionsEnData(dataHora);
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();

            if (particAVendre <= 0)
                return compresAmbParticipacio;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = Prod.MovimentsProducteUsuari.Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?)s.Participacions) ?? 0;
            var trobadaPrimeraCompra = false;

            // Llegeix compres anteriors a la venda del producte ordenades per data creixent i vaig restant les participacions venudes anteriorment.
            var conpresAnt = Prod.MovimentsProducteUsuari.Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ToList();
            foreach (var compra in conpresAnt)
            {
                if (!trobadaPrimeraCompra)
                {
                    if (participVenudesAbans >= compra.Participacions)
                    {
                        // Son les participacions que ja estan venude per una venda anterior.
                        participVenudesAbans = Math.Round(participVenudesAbans - compra.Participacions, 5);
                    }
                    else
                    {
                        var part = compra.Participacions - participVenudesAbans;
                        if (part > particAVendre)
                            part = particAVendre;
                        compresAmbParticipacio.Add(new MovimentCompra(compra, part));
                        particAVendre -= part;
                        trobadaPrimeraCompra = true;
                    }
                }
                else
                {
                    //double part = participacions > compra.Participacions ? participacions - compra.Participacions : participacions;
                    double part = particAVendre > compra.Participacions ? compra.Participacions : particAVendre;
                    compresAmbParticipacio.Add(new MovimentCompra(compra, part));
                    particAVendre -= part;
                }

                if (Utilitats.EsZero(particAVendre))
                    break;
            }

            if (particAVendre > 0.0000001)
                throw new ApplicationException("No hi ha prou participacions disponibles en cartera en aquesta data: " + dataHora.ToShortDateString() + " " + dataHora.ToShortTimeString());

            return compresAmbParticipacio;
        }


        private static Dictionary<Moviment, double> CompresDescomptades;

        /// <summary>
        /// Torna el numero de participacions del producte a partir d'aquest moviment.
        /// </summary>
        /// <returns></returns>
        double saldoParticipacions()
        {
            if (!_EsCompra && !_EsVenda)
                throw new ApplicationException("Només tenen saldo moviments de compra, venda i traspassos");

            double saldo = _EsCompra ? Participacions : -Participacions;

            foreach (var mov in Program.Sessio.MovimentsUsuari.Where(w => w.ProdId == ProdId && w.Data < Data).OrderBy(o => o.Data))
            {
                if (mov._EsCompra)
                    saldo += mov.Participacions;
                else if(mov._EsVenda)
                    saldo -= mov.Participacions;
            }
            return Math.Round(saldo, 5);
        }

        internal IEnumerable<MovimentCompra> trobaCompresReals()
        {
            CompresDescomptades = new Dictionary<Moviment, double>();
            
            var result = trobaCompresReals(this.Participacions);

            Program.Sessio.desfaCanvisPendentsEnTaula(typeof(Moviment));
            
            return result;
        }


        private IEnumerable<MovimentCompra> trobaCompresReals(double numPart)
        {
            if (!_EsVenda)
                throw new ApplicationException("Aquest mètode només es pot cridar si el moviment es una venda i aquest es: " + TipusMoviment);

            List<MovimentCompra> compresReals = new List<MovimentCompra>();
            var compresAnt = compresAnteriors(numPart).ToList();

            //var idPrimeraCompra = compresAnt.OrderBy(o => o._Moviment.Id).First()._Moviment.Id;

            //var vendaAnt = Program.Sessio.MovimentsUsuari.FirstOrDefault(w => w.ProdId == ProdId && w._EsVenda && w.Id > idPrimeraCompra && w.Id < Id);

            //if (vendaAnt != null)
            //    compresReals.AddRange(vendaAnt.trobaCompresReals(vendaAnt.Participacions));
            

            foreach (var compra in compresAnt)
            {
                if (compra._Moviment._EsCompraReal)
                {
                    MovimentCompra compraX = compra;
                    double part = 0;
                    if (CompresDescomptades.ContainsKey(compra._Moviment))
                    {
                        if (compraX._ParticipacionsDisponibles < CompresDescomptades[compra._Moviment])
                            part = compraX._ParticipacionsDisponibles;
                        else
                            part = CompresDescomptades[compra._Moviment];

                        compraX._ParticipacionsDisponibles -= part;
                    }

                    compresReals.Add(compraX);

                    compra._Moviment.Participacions -= compraX._ParticipacionsDisponibles;

                    if (CompresDescomptades.ContainsKey(compra._Moviment))
                    {
                        CompresDescomptades[compra._Moviment] += compra._ParticipacionsDisponibles;
                    }
                    else
                    {
                        CompresDescomptades.Add(compra._Moviment, compra._ParticipacionsDisponibles);
                    }
                }
                else
                {
                    var venda = compra._Moviment.MovimentRefVenda;
                    var numPartX = compra._ParticipacionsDisponibles / compra._Moviment.Participacions * venda.Participacions;
                    compresReals.AddRange(venda.trobaCompresReals(numPartX));

                    compra._Moviment.Participacions -= compra._ParticipacionsDisponibles;
                }
            }
            return compresReals;
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
