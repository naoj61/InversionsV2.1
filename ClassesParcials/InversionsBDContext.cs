using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    public partial class InversionsBDContext
    {
        private ObjectContext _Context
        {
            get { return ((IObjectContextAdapter) this).ObjectContext; }
        }


        /// <summary>
        /// Refresca totes les taules de la BD
        /// </summary>
        public void refrescaTot()
        {
            var context = ((IObjectContextAdapter) this).ObjectContext;

            var objects = (context.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added |
                EntityState.Deleted |
                EntityState.Modified |
                EntityState.Unchanged)
                .Where(entry => entry.EntityKey != null)
                .Select(entry => entry.Entity));

            context.Refresh(RefreshMode.StoreWins, objects);
        }


        /// <summary>
        /// Refresca només una taula.
        /// </summary>
        /// <param name="entityType"></param>
        public void refrescaTaula(Type entityType)
        {
            var context = ((IObjectContextAdapter) this).ObjectContext;

            var objects = context.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added |
                EntityState.Deleted |
                EntityState.Modified |
                EntityState.Unchanged)
                .Where(x => x.EntityKey != null && ObjectContext.GetObjectType(x.Entity.GetType()) == entityType)
                .Select(e => e.Entity);

            context.Refresh(RefreshMode.StoreWins, objects);
        }


        /// <summary>
        /// Desfà els canvis pendents de "entity"
        /// </summary>
        /// <param name="entity"></param>
        internal void UndoingChangesDbEntityPropertyLevel(object entity)
        {
            DbEntityEntry entry = this.Entry(entity);
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
                var dbSet = this.Empreses;

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
                var dbSet = this.Gestors;

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


        public virtual DbSet<ProdFons> ProdFons { get; set; }
        public virtual DbSet<ProdAccions> ProdAccions { get; set; }
        public virtual DbSet<Valoracio> Valoracio { get; set; }
        public IEnumerable<Moviment> MovimentsUsuari
        {
            get { return Moviments.Where(w => w.IdUsuari == Usuari.Seleccionat.Id); }
        }

    }
}
