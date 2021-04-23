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


        /// <summary>
        /// L'utilitzo per saber les participacions disponibles que poden no ser les mateixes que les del moviment.
        /// </summary>
        public double _ParticipacionsDisponibles
        {
            get { return vParticipacionsDisponibles.GetValueOrDefault(Participacions); }
            set
            {
                if (Utilitats.ComparaNumeros(value, Participacions, 4) > 0)
                    throw new Exception("El valor no pot ser superior a 'Participacions'");
                vParticipacionsDisponibles = value;
            }
        }
        private double? vParticipacionsDisponibles;

        #endregion *** Atributs ***

        #region *** Mètodes ***


        /// <summary>
        /// Reseteja el valor de vParticipacionsDisponibles dels moviments del paràmetre.
        /// </summary>
        /// <param name="desglosCompres">Llista de moviments a resetejar.</param>
        public static void ResetParticipacionsDisponibles(IEnumerable<DesglosCompra> desglosCompres)
        {
            foreach (var desg in desglosCompres)
            {
                desg.vParticipacionsDisponibles = null;
            }
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
