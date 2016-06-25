using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    public partial class Valoracio : IComparable<Valoracio>
    {
        public struct MyStruct
        {
            private DateTime vData;
            private double import;
        }

        public double _VariacioPercentatge
        {
            get
            {
                var v1 = MyClass.Sessio.Valoracions.Where(w => w.Prod.Id == Prod.Id && w.Data < Data).OrderBy(o => o.Data).ToList();
                if (v1.Count == 0)
                    return 0;

                return PreuParticipacio / v1.Last().PreuParticipacio - 1;
            }
        }

        public double _VariacioEuros
        {
            get
            {
                var v1 = MyClass.Sessio.Valoracions.Where(w => w.Prod.Id == Prod.Id && w.Id < Id).OrderBy(o => o.Data).ToList();
                if (v1.Count == 0)
                    return 0;


                return (PreuParticipacio * Prod._Participacions) - (v1.Last().PreuParticipacio * Prod._Participacions);
            }
        }

        /// <summary>
        /// Valoració total en funció de les participacions
        /// </summary>
        public double _ValoracioTotal
        {
            get { return PreuParticipacio * Prod.participacions(new Producte.DateTimeFinalDia(Data)); }
        }

        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }


        public static bool operator <(Valoracio a, Valoracio b)
        {
            return a != b && (b != null && (a != null && a.Id < b.Id));
        }

        public static bool operator >(Valoracio a, Valoracio b)
        {
            return a != b && (b != null && (a != null && a.Id > b.Id));
        }

        public static bool operator ==(Valoracio a, Valoracio b)
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

        public static bool operator !=(Valoracio a, Valoracio b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Valoracio))
                return false;

            return this == (Valoracio) obj;
        }

        public override string ToString()
        {
            return Id.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        public int CompareTo(Valoracio other)
        {
            if (Id < other.Id)
                return -1;
            return Id > other.Id ? 1 : 0;
        }
    }
}
