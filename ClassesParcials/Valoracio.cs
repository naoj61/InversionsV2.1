using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Comuns;
using Inversions.GUI;

namespace Inversions
{
    public partial class Valoracio : IComparable<Valoracio>
    {

        public static DbSet<Valoracio> Tuples
        {
            get { return Program.Sessio.Valoracions; }
        }

        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof(Valoracio));

            // Fa que es recarreguin el "ICollection" de la taula.
            var xx = Tuples.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valoracio"></param>
        public static void Reload(Valoracio valoracio)
        {
            Program.Sessio.Entry(valoracio).Reload();
        }

        /// <summary>
        /// La valoració anterior.
        /// </summary>
        /// <param name="preuMajorQueCero">Si true. La valoració anterior amb preu superior a 0.</param>
        /// <returns></returns>
        internal Valoracio trobaValoracioAnterior(bool preuMajorQueCero)
        {
            var valoracionsAnteriors = Valoracio.Tuples.Where(w => w.Prod.Id == Prod.Id && w.Data < Data);

            if (preuMajorQueCero)
                valoracionsAnteriors = valoracionsAnteriors.Where(w => w.PreuParticipacio > 0);

            return valoracionsAnteriors.Any() ? valoracionsAnteriors.OrderByDescending(e => e.Data).FirstOrDefault() : null;
        }


        /// <summary>
        /// Expressió per seleccionar pendents en un LINQ.
        /// </summary>
        public static Expression<Func<Valoracio, bool>> ExpHiHaParticipacions
        {
            get
            {
                return p => p.Prod != null && p.Prod.Moviments.Where(w => w.UsuariId == Usuari.Seleccionat.Id && w.Data <= p.Data).Sum(s => s.Participacions) > 0;
            }
        }

        /// <summary>
        /// Número de participacions en la data de la valoració.
        /// </summary>
        public decimal _NumParticipacions
        {
            get
            {
                return Prod == null ? 0 : Prod.partsEnCartera(Utilitats.DataHoraFinalDia(Data));
            }
        }


        /// <summary>
        /// Crea una nova valoració.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="producte"></param>
        /// <param name="data"></param>
        /// <param name="import"></param>
        internal static Valoracio Nova(InversionsBDContext conn, Producte producte, DateTime data, decimal import)
        {
            // Alta
            Valoracio val = null;
            try
            {
                val = conn.Valoracio.Create();
                val.ProdId = producte.Id;
                val.Data = data;
                val.PreuParticipacio = import;

                conn.Valoracions.Add(val);
                //conn.SaveChanges();
            }
            catch (DbUpdateException ex2)
            {
                Comuns.Utilitats.EscriuLog(ex2, Program.FitxerLog, Program.Versio);
                conn.UndoingChangesDbEntityPropertyLevel(val);
                if (ex2.InnerException != null)
                    if (ex2.InnerException.InnerException != null)
                        throw ex2.InnerException.InnerException;
                    else
                        throw ex2.InnerException;
                else
                    throw;
            }
            catch (Exception ex)
            {
                Comuns.Utilitats.EscriuLog(ex, Program.FitxerLog, Program.Versio);
                conn.UndoingChangesDbEntityPropertyLevel(val);
                throw;
            }

            return val;
        }

        /// <summary>
        /// Modifica una valoració
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="data"></param>
        /// <param name="import"></param>
        internal void modifica(InversionsBDContext conn, DateTime data, decimal import)
        {
            Valoracio val = null;
            try
            {
                // Modificacio
                //val = conn.Valoracions.Single(s => s.Id == this.Id);
                val = conn.Valoracions.Find(Id);

                val.Data = data;
                val.PreuParticipacio = import;

                conn.Valoracions.AddOrUpdate(val);
                //conn.SaveChanges();
            }
            catch (DbUpdateException ex2)
            {
                Comuns.Utilitats.EscriuLog(ex2, Program.FitxerLog, Program.Versio);
                conn.UndoingChangesDbEntityPropertyLevel(val);
                throw ex2.InnerException.InnerException;
            }
            catch (Exception ex)
            {
                Comuns.Utilitats.EscriuLog(ex, Program.FitxerLog, Program.Versio);
                conn.UndoingChangesDbEntityPropertyLevel(val);
                throw;
            }
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
