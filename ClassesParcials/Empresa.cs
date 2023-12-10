using System.Data.Entity;
using System.Linq;

namespace Inversions
{
    using System;
    using System.Collections.Generic;

    public partial class Empresa
    {

        public static DbSet<Empresa> Tuples
        {
            get { return Program.Sessio.Empreses; }
        }

        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof(Empresa));

            // Fa que es recarreguin el "ICollection" de la taula.
            var xx = Tuples.ToList();
        }

        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Empresa a, Empresa b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null,return false.
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Id == b.Id;
        }

        public static bool operator !=(Empresa a, Empresa b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Empresa))
                return false;

            return this == (Empresa)obj;
        }

        public override string ToString()
        {
            return Nom;
        }

        #endregion

    }
}
