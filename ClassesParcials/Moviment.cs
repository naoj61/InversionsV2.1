using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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

        /// <summary>
        /// Torna el pig actual des de
        /// </summary>
        /// <returns></returns>
        public double pig()
        {
            double pig = 0;
            //foreach (var mov in MovimentsProducte.OrderByDescending(o => o.Data).ToList())
            {
                if (IdRefVenda.HasValue)
                    // És un traspàs de compra
                    pig = Program.Sessio.Moviments.Single(s => s.Id == IdRefVenda.Value).pig();
                else
                {
                    if (_EsCompraReal)
                    {
                        // És una compra
                    }
                    else if(_EsVenda)
                    {
                        // És una venda real o no.
                        pig = PreuParticipacio * Participacions - Despeses.GetValueOrDefault();
                        double partsRestants = Participacions;
                        foreach (var mov in Prod.MovimentsProducte.Where(w=>w.Data <= Data).OrderByDescending(o=>o.Data).ToList())
                        {
                            Debug.Assert(mov._EsCompra, "No pot ser una venda");

                            var parts = partsRestants > mov.Participacions ? mov.Participacions : partsRestants;

                            pig -= mov.PreuParticipacio * mov.Participacions + mov.Despeses.GetValueOrDefault();

                            if(partsRestants == parts)
                                break;

                            partsRestants -= parts;
                        }
                    }
                    else
                    {
                        Debug.Assert(false, "No hauria d'arribar aquí");
                    }
                }
            }

            return pig;
        }
  
        
        /*
         * En cada traspàs hauria de desar el valor de la compra original, com que el número de participacions canvia en funció del producte, 
         * hauria de desar l'import total per si hi ha un traspàs posterior parcial obtenir el balor original de la part traspassada.
         */

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
