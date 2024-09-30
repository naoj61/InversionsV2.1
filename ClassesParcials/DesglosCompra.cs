using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;

namespace Inversions
{
    public partial class DesglosCompra
    {
        public static DbSet<DesglosCompra> Tuples
        {
            get { return Program.Sessio.DesglosCompres; }
        }

        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof(DesglosCompra));

            // Fa que es recarreguin el "ICollection" de la taula.
            var xx = Tuples.ToList();
        }

        #region *** Atributs ***

        public decimal _PreuParticipacioOrig
        {
            get { return MovCompraOrig.PreuParticipacio; }
        }

        public decimal _PreuParticipacio
        {
            get { return MovCompra.PreuParticipacio; }
        }

        public DateTime _DataOrig
        {
            get { return MovCompraOrig.Data; }
        }


        #endregion *** Atributs ***


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
