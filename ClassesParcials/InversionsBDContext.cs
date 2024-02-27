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
        /// Troba l'entity type a partir del nom de la taula. Ex Valoracions --> Valoracio
        /// </summary>
        /// <param name="nomTaula"></param>
        /// <returns></returns>
        private Type GetEntityType(string nomTaula)
        {
            // Si el nom taula conté '_' és que es una taula amb herencia, la part esquerra de '_' s'ha de descartar.
            if (nomTaula.Contains("_"))
                nomTaula = nomTaula.Substring(nomTaula.IndexOf('_') + 1);

            // Busquem la propietat DbSet corresponent al nom del conjunt d'entitats utilitzant reflexió
            var dbSetProperty = this.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                     p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                     p.Name == nomTaula);

            // Si no s'ha trobat cap coincidència, retornem null
            return dbSetProperty != null ? dbSetProperty.PropertyType.GetGenericArguments().FirstOrDefault() : null;
        }

        /// <summary>
        /// Refresca només una taula a partir del nom.
        /// </summary>
        /// <param name="nomTaula"></param>
        public void refrescaTaula(string nomTaula)
        {
            var entityType = GetEntityType(nomTaula);
           
            if (entityType == null)
                throw new Exception("La taula: " + nomTaula + " no existeix");

            refrescaTaula(entityType);
        }

        /// <summary>
        /// Refresca només una taula a partir del Type.
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
        /// Refresca totes les taules de la BD
        /// </summary>
        public void refrescaTot()
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;

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

                if (entity.Nom == "")
                    list.Add(new DbValidationError("Nom", "El Nom és obligatori"));

                //if (entityEntry.State == EntityState.Added
                //    && dbSet.SingleOrDefault(f => f.Id == entity.Id) != null)
                //    list.Add(new DbValidationError("Id", "Duplicate key"));

                if (Empreses.Any(f => f.Nom == entity.Nom && f.Id != entity.Id))
                    list.Add(new DbValidationError("Nom", "Clau duplicada"));
            }
            else if (entityEntry.Entity is Gestor)
            {
                Gestor entity = entityEntry.Entity as Gestor;

                if (entity.Nom == "")
                    list.Add(new DbValidationError("Nom", "Nom is required"));

                if (Gestors.Any(f => f.Nom == entity.Nom && f.Id != entity.Id))
                    list.Add(new DbValidationError("Nom", "Duplicate key"));
            }
            else if (entityEntry.Entity is ProdFons)
            {
                ProdFons entity = entityEntry.Entity as ProdFons;

                if (entity.Nom == "")
                    list.Add(new DbValidationError("Nom", "Nom is required"));

                if (ProdFons.Any(f => f.Nom == entity.Nom && f.Id != entity.Id))
                    list.Add(new DbValidationError("Nom", "Duplicate key"));


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
    }
}
