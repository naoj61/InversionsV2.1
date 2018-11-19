using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Inversions
{
    public partial class DesglosCompra
    {

        #region *** Atributs ***

        public double _PreuPartOrig
        {
            get { return MovimentOrig.PreuParticipacio; }
        }

        public double _PreuParticipacio
        {
            get { return Moviment.PreuParticipacio; }
        }

        public DateTime _DataMovimentOrig
        {
            get { return MovimentOrig.Data; }
        }

        public DateTime _DataMoviment
        {
            get { return Moviment.Data; }
        }

        #endregion *** Atributs ***

        #region *** Mètodes ***

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

            return this == (DesglosCompra) obj;
        }


        public override string ToString()
        {
            return String.Format("Id={0}. MovId={1}. MovOrigId={2}", Id, Moviment.Id, MovimentOrig.Id);
        }

        #endregion
    }
}
