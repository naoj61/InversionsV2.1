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

        public double? _ValorCompraOriginalPreuUnitari
        {
            get { return ValorCompraOriginal.HasValue ? (double?) ValorCompraOriginal.Value / Participacions : null; }
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



        /// <summary>
        /// Calcula 
        /// </summary>
        /// <returns></returns>
        public double? calculaPreuUnitariOrigen()
        {
            if (TipusMoviment == TipusMoviment.Compra)
            {
                if (_EsTraspas)
                {
                    /* 
                     * És traspàs compra. 
                     * Preu Unitari Origen = Preu U. Venda Ponderat. Sempre està lligat a una sola venda.
                     */
                    Moviment vendaTraspas = Program.Sessio.Moviments.Single(w => w.Id == IdRefVenda);
                    return vendaTraspas.PreuParticipacioOrigen * vendaTraspas.Participacions / Participacions;
                }
                else
                {
                    /* 
                     * És Compra normal. 
                     * Preu Unitari Origen = Preu Unitari.
                     */
                    return PreuParticipacio;
                }
            }

            if (TipusMoviment == TipusMoviment.Venda)
            {
                /*
                 * És Venda o traspàs venda.
                 * Preu Unitari Origen = Mitjana del Preu Unitari Origen de les unitats de les compres afectades
                */
                double x = 0;
                double y = 0;
                foreach (var compra in compresAnteriorsVenda())
                {
                    x += compra._ParticipacionsRestants * compra._Moviment.PreuParticipacioOrigen.GetValueOrDefault();
                    y += compra._ParticipacionsRestants;
                }

                return x / y;
            }
         
            throw new ApplicationException(String.Format("Tipus de moviment incorrecte. If={0}. Tipus mov.:{1})", Id, TipusMoviment));
        }


        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora de la venda fins que cobreixin el número de participacions de la venda.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Producte.MovimentCompra> compresAnteriorsVenda()
        {
            if (TipusMoviment != TipusMoviment.Venda)
                throw new ApplicationException(String.Format("Tipus de moviment incorrecte. No és una venda. . If={0}. Tipus mov.:{1})", Id, TipusMoviment));

            return this.Prod.compresAnteriors(this.Data, this.Participacions);
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
