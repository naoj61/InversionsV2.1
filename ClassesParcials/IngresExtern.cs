using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Inversions.ClassesEntity
{
    public partial class IngresExtern
    {
// ReSharper disable once MemberCanBePrivate.Global
        public static DbSet<IngresExtern> Tuples
        {
            get { return Program.Sessio.IngressosExterns; }
        }

        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof (IngresExtern));

            // Fa que es recarreguin el "ICollection" de la taula.
            List<IngresExtern> xx = Tuples.ToList();
        }

        #region *** Atributs ***

        #endregion *** Atributs ***

        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(IngresExtern a, IngresExtern b)
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

        public static bool operator !=(IngresExtern a, IngresExtern b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DesglosCompra))
                return false;

            return this == (IngresExtern) obj;
        }

        public override string ToString()
        {
            return String.Format("Id={0}. Usuari={1}. Any={2}. Rao={3}", Id, Usuari, Any, Rao);
        }

        #endregion
    }
}