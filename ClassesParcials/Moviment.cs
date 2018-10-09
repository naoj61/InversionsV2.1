using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Comuns;

namespace Inversions
{

    /// <summary>
    /// El moviment de compra lligadas a una venda pot ser que no utilitzi totes les participacions.
    /// </summary>
    public struct MovimentCompra
    {
        public Moviment _Moviment { get; private set; }
        public double _ParticipacionsDisponibles { get; private set; }

        public MovimentCompra(Moviment moviment, double participacionsDisponibles)
            : this()
        {
            if(!moviment._EsCompra)
                throw new ArgumentException("El moviment ha de ser una compra.", "moviment");

            _Moviment = moviment;
            _ParticipacionsDisponibles = participacionsDisponibles;
        }
    }

    public partial class Moviment
    {
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
        /// Calcula el preu de compra origen d'un moviment de; Compra, venda o traspàs.
        /// </summary>
        /// <returns></returns>
        internal double calculaPreuOrigen()
        {
            double valorRetorn;

            if (TipusMoviment == TipusMoviment.Compra)
            {
                if (MovimentRefVenda == null)
                {
                    valorRetorn = PreuParticipacio;
                }
                else
                {
                    if (MovimentRefVenda.PreuParticipacioOrigen == null)
                        throw new NullReferenceException("El 'movimentVendaVinculatCompra' és NULL i hauria de tenir algún valor.");

                    valorRetorn = MovimentRefVenda.PreuParticipacioOrigen.Value * MovimentRefVenda.Participacions / Participacions;
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
