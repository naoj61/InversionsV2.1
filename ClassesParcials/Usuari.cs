using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.ClassesEntity
{
    public partial class Usuari
    {
        public enum Usuaris
        {
            Joan = 1,
// ReSharper disable UnusedMember.Global
            Carme = 2
// ReSharper restore UnusedMember.Global
        }


        public static DbSet<Usuari> Tuples
        {
            get { return Program.Sessio.Usuaris; }
        }

// ReSharper disable UnusedMember.Global
        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof(Usuari));

            // Fa que es recarreguin el "ICollection" de la taula.
            var xx = Tuples.ToList();
        }
        // ReSharper restore UnusedMember.Global

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
