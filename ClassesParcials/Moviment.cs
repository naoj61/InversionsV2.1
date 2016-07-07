using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    public partial class Moviment
    {
        public string _NomProducteTraspasOrigen
        {
            get { return (TipusMoviment == TipusMoviment.Compra || ProducteTraspas == null)  ? null : ProducteTraspas._NomProducte; }
        }

        public string _NomProducteTraspasDesti
        {
            get { return (TipusMoviment == TipusMoviment.Venda || ProducteTraspas == null) ? null : ProducteTraspas._NomProducte; }
        }


        /// <summary>
        /// Torna tipus movimen en string i indica els traspassos.
        /// </summary>
        public string _TipusMoviment
        {
            get
            {
                string result;

                if (_EsDividents)
                    result = TipusMoviment.Dividends.ToString();

                if (_EsCompra)
                {
                    if (_EsTraspas)
                        result = "Traspàs C";
                    else
                        result = TipusMoviment.Compra.ToString();
                }
                else
                {
                    if (_EsTraspas)
                        result = "Traspàs V";
                    else
                        result = TipusMoviment.Venda.ToString();
                }

                return result;
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

        public double Import
        {
            get
            {
                double result;
                if (Participacions == 0)
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

        /*
        /// <summary>
        /// Calcula el PiG si el moviment és una venda.
        /// Invlou despeses.
        /// No inclou dividents.
        /// </summary>
        /// <returns></returns>
        public double pig()
        {
            if (!_EsVendaReal)
                return 0;

            double pig = 0;

            List<Moviment> compres = new List<Moviment>();

            foreach (var compra in this.Prod.MovimentsProducte.Where(w=>w._EsCompra && w.Data < Data))
            {
                compres.Add(buscaCompraOrigen(compra));
            }


            return pig
        }

        private Moviment buscaCompraOrigen(Moviment compra)
        {
            if(!compra._EsCompra)
                throw new ArgumentException("El moviment ha de ser una compra.", "compra");

            if (compra._EsCompraReal)
                return compra;
            
            buscaCompraOrigen(compra.ProducteTraspas)
        }
        */


        public Moviment Duplica()
        {
            Moviment mov = (Moviment)MemberwiseClone();
            mov.Id = 0;
            mov.RowVersion = null;

            return mov;
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
