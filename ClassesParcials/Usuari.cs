using System;
using System.Windows.Forms;

namespace Inversions
{
    public partial class Usuari
    {
        public enum Usuaris
        {
            Joan = 1,
            Carme = 2
        }

        public static Usuari Seleccionat { get; set; }

        #region Overrides

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Usuari a, Usuari b)
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

        public static bool operator !=(Usuari a, Usuari b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Usuari))
                return false;

            return this == (Usuari)obj;
        }

        public override string ToString()
        {
            return String.Format("[{0}] - {1}", Id, Nom);
        }

        #endregion
    }
}
