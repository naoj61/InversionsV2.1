using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Inversions.ClassesEntity
{
    public partial class Mercat
    {
        public static DbSet<Mercat> Tuples
        {
            get { return Program.Sessio.Mercats; }
        }

// ReSharper disable UnusedMember.Global
        public static void RefrescaTaula()
// ReSharper restore UnusedMember.Global
        {
            Program.Sessio.refrescaTaula(typeof (Mercat));

            // Fa que es recarreguin el "ICollection" de la taula.
            List<Mercat> xx = Tuples.ToList();
        }

        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Mercat a, Mercat b)
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

        public static bool operator !=(Mercat a, Mercat b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Mercat))
                return false;

            return this == (Mercat) obj;
        }

        public override string ToString()
        {
            return Nom;
        }

        #endregion
    }
}