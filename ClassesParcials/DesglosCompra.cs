using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;

namespace Inversions
{
    public partial class DesglosCompra
    {

        #region *** Atributs ***

        public double _PreuParticipacioOrig
        {
            get { return MovCompraOrig.PreuParticipacio; }
        }

        public double _PreuParticipacio
        {
            get { return MovCompra.PreuParticipacio; }
        }

        public DateTime _DataOrig
        {
            get { return MovCompraOrig.Data; }
        }

        // todo He de diferenciar entre participacions Ocupades(per altres moviments), Utilitzades(en aquest moviment) i Disponibles(la resta).

        /// <summary>
        /// Son les participacions originals utilitzades en aquest moviment.
        /// </summary>
        public double _ParticipacionsUtilitzadesOrig
        {
            get { return ParticipacionsOrig / Participacions * _ParticipacionsUtilitzades; }
        }

        /// <summary>
        /// Son les participacions utilitzades en moviments anteriors.
        /// </summary>
        public double _ParticipacionsOcupades
        {
            get { return vParticipacionsOcupades; }
            set
            {
                if (Utilitats.ComparaNumeros(value, Participacions - vParticipacionsUtilitzades) > 0)
                    throw new Exception("El valor no pot ser superior a 'Participacions disponibles'");

                vParticipacionsOcupades = value;
            }
        }
        private double vParticipacionsOcupades;

        /// <summary>
        /// Son les participacions utilitzades en aquest moviment.
        /// </summary>
        public double _ParticipacionsUtilitzades
        {
            get { return vParticipacionsUtilitzades; }
            set
            {
                if (Utilitats.ComparaNumeros(value, Participacions - vParticipacionsOcupades) > 0)
                    throw new Exception("El valor no pot ser superior a 'Participacions disponibles'");

                vParticipacionsUtilitzades = value;
            }
        }
        private double vParticipacionsUtilitzades;

        /// <summary>
        /// Son les participacions no utilitzades en aquest moviment.
        /// </summary>
        public double _ParticipacionsDisponibles
        {
            get { return Participacions - vParticipacionsOcupades - vParticipacionsUtilitzades; }
        }

        #endregion *** Atributs ***

        #region *** Mètodes ***
        
        /// <summary>
        /// Reseteja Participacions utilitzades i ocupades.
        /// </summary>
        internal void resetParticipacionsDeTreball()
        {
            vParticipacionsUtilitzades = 0;
            vParticipacionsOcupades = 0;
        }

        /// <summary>
        /// Converteix el número de participacions del moviment al numero de particions originals.
        /// </summary>
        /// <param name="partsDelMoviment"></param>
        /// <returns></returns>
        internal double calculaPartsMovAPartsOrig(double partsDelMoviment)
        {
            if (Utilitats.ComparaNumeros(partsDelMoviment, Participacions) > 0)
                throw new ArgumentException("El valor de partsDelMoviment és més gran que el total de particions.");
            
            return partsDelMoviment / Participacions * ParticipacionsOrig;
        }


        /// <summary>
        /// Torna les participacions que encara hi ha en cartera de una compra real. No serveix per traspassos.
        /// La compra ha de pertanyer a un fons d'inversió.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static double PartsEnCarteraCompraReal(Moviment compra)
        {
            if (!compra._EsCompraReal)
                throw new Exception(String.Format("L'Id:{0}, no és una compra real", compra.Id));

            if (!(compra.Prod is ProdFons))
                throw new Exception(String.Format("L'Id:{0}, no pertany a un fons d'inversió", compra.Id));

            // Si és una compra real, només hi pot haver un element a DesglosCompres.
            var desgloç = compra.DesglosCompres.Single();
          
            return desgloç.partsEnCarteraCompraReal(compra.Participacions);
        }

        /// <summary>
        /// Torna les participacions que encara hi ha en cartera de una compra real. No serveix per traspassos.
        /// La compra ha de pertanyer a un fons d'inversió.
        /// </summary>
        /// <param name="parts">Participacions que queden per vendre.</param>
        /// <returns></returns>
        private double partsEnCarteraCompraReal(double parts)
        {
            var compraOrig = MovCompraOrig;
            var compra = MovCompra;
            var vendes = compra.vendesDeLaCompra();
           
            foreach (var venda in vendes)
            {
                if (venda._EsTraspas)
                {
                    // venda.Id==100 dona error.
                    var cOrig = venda._MovimentRefCompra.DesglosCompres.SingleOrDefault(w => w.MovCompraOrig == compraOrig);
                    if (cOrig != null) 
                        parts = cOrig.partsEnCarteraCompraReal(parts);
                }
                else
                {
                    var pa = ParticipacionsOrig / compra.Participacions * venda._ParticipacionsUtilitzades;
                    parts -= pa;
                }
            }

            return parts;
        }

        #endregion *** Mètodes ***

        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(DesglosCompra a, DesglosCompra b)
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

        public static bool operator !=(DesglosCompra a, DesglosCompra b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DesglosCompra))
                return false;

            return this == (DesglosCompra)obj;
        }

        public override string ToString()
        {
            return String.Format("Id={0}. MovId={1}. MovOrigId={2}", Id, MovCompraId, MovCompraOrigId);
        }

        #endregion
    }
}
