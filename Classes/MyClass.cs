using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Inversions
{
    public class MyClass : InversionsBDContainer
    {
        internal static readonly MyClass Sessio;
        internal static readonly bool DesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public MyClass(string nomConnexio) : base(nomConnexio)
        {
        }

        internal static ObjectContext SessioContextAdapter {
            get { return ((IObjectContextAdapter) Sessio).ObjectContext; }
        }

        static MyClass()
        {
            Sessio = new MyClass("InversionsBDContainer");
            Sessio.Configuration.AutoDetectChangesEnabled = false; // Si poso true, dona error quan inserto una fila i l'esborro en la mateixa sessió.
            Sessio.Configuration.LazyLoadingEnabled = true;
        }

        public static ObjectContext Context { get { return ((IObjectContextAdapter)Sessio).ObjectContext; } }

        /// <summary>
        /// Torna la data del dia anterior laborable.
        /// No té calendari de festius, només te en compte dissabtes i diumenges.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static DateTime AnteriorDiaLaborable(DateTime data)
        {
            DateTime dataAnt = data;
            do
            {
                dataAnt = dataAnt.AddDays(-1);

            } while (dataAnt.DayOfWeek == DayOfWeek.Saturday || dataAnt.DayOfWeek == DayOfWeek.Sunday);

            return dataAnt;
        }


        /// <summary>
        /// Desfà els canvis pendents de "entity"
        /// </summary>
        /// <param name="entity"></param>
        internal static void UndoingChangesDbEntityPropertyLevel(object entity)
        {
            DbEntityEntry entry = Sessio.Entry(entity);
            if (entry.State == EntityState.Added || entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Detached;
            }
            else
            {
                entry.State = EntityState.Unchanged;
            }
        }


        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var list = new List<DbValidationError>();

            if (entityEntry.Entity is Empresa)
            {
                Empresa entity = entityEntry.Entity as Empresa;
                var dbSet = Sessio.Empreses;

                if (entity.Nom == "")
                    list.Add(new DbValidationError("Nom", "Nom is required"));

                //if (entityEntry.State == EntityState.Added
                //    && dbSet.SingleOrDefault(f => f.Id == entity.Id) != null)
                //    list.Add(new DbValidationError("Id", "Duplicate key"));

                if (dbSet.SingleOrDefault(f => f.Nom == entity.Nom) != null)
                    list.Add(new DbValidationError("Nom", "Duplicate key"));
            }
            else if (entityEntry.Entity is Gestor)
            {
                Gestor entity = entityEntry.Entity as Gestor;
                var dbSet = Sessio.Gestors;

                if (entity.Nom == "")
                    list.Add(new DbValidationError("Nom", "Nom is required"));

                if (dbSet.SingleOrDefault(f => f.Nom == entity.Nom) != null)
                    list.Add(new DbValidationError("Nom", "Duplicate key"));
            }
            else if (entityEntry.Entity is ProdFons)
            {
                ProdFons entity = entityEntry.Entity as ProdFons;
                if (entity.Gestors.Count > 0)
                {
                    // Valida que tots els gestors siguin de la mateixa empresa.
                    if (entity.Gestors.GroupBy(s => s.EmpresaId).Count() > 1)
                        list.Add(new DbValidationError("Gestor", "Tots els gestors han de pertanyer a la mateixa empresa."));

                    // Valida que l'empresa del gestor i la del producte, siguin la mateixa.
                    if (entity.EmpresaId != entity.Gestors.First().EmpresaId)
                        list.Add(new DbValidationError("Empresa", "No coincideix empresa gestor i empresa producte."));
                }
            }

            if (list.Count > 0)
                return new DbEntityValidationResult(entityEntry, list);
            else
                return base.ValidateEntity(entityEntry, items);
        }
    }
}