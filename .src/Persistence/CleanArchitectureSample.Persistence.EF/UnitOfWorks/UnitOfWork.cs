using CleanArchitectureSample.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Persistence.EF.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructors
        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }
        #endregion

        #region Context
        private DbContext Context { get; }
        #endregion

        #region Saving Methods
        public int Save(string userId = null)
        {
            //In all versions of Entity Framework, whenever you execute SaveChanges() to insert, update or delete on the 
            //database the framework will wrap that operation in a transaction. This transaction lasts only long enough to             
            //execute the operation and then completes. When you execute another such operation a new transaction is started.
            int rowsCount = 0;
            var EntitiesErrors = Context.ValidateEntities();

            if (EntitiesErrors.Count > 0)
            {
                foreach (var EntityErrors in EntitiesErrors)
                {
                    foreach (var validationError in EntityErrors.Value)
                    {
                        var errorMessage =
                            $"Entity: {EntityErrors.Key}\nProperty: {validationError.MemberNames}\n{validationError.ErrorMessage}";
                        var EntitiesException = new Exception(errorMessage);
                        EntitiesException.Data["PropertyName"] = validationError.MemberNames;
                        EntitiesException.Data["EntityName"] = EntityErrors.Key;
                        // Logger.Error(exception, errorMessage);
                        throw EntitiesException;
                    }
                }
            }
            this.UpdatePropertiesBeforeSave(userId);
            rowsCount = this.Context.SaveChanges();

            return rowsCount;
        }

        public async Task<int> SaveAsync(string userId = null)
        {
            int rowsCount = 0;
            var EntitiesErrors = Context.ValidateEntities();

            if (EntitiesErrors.Count > 0)
            {
                foreach (var EntityErrors in EntitiesErrors)
                {
                    foreach (var validationError in EntityErrors.Value)
                    {
                        var errorMessage =
                            $"Entity: {EntityErrors.Key}\nProperty: {validationError.MemberNames}\n{validationError.ErrorMessage}";
                        var EntitiesException = new Exception(errorMessage);
                        EntitiesException.Data["PropertyName"] = validationError.MemberNames;
                        EntitiesException.Data["EntityName"] = EntityErrors.Key;
                        // Logger.Error(exception, errorMessage);
                        throw EntitiesException;
                    }
                }
            }
            this.UpdatePropertiesBeforeSave(userId);

            return rowsCount = await this.Context.SaveChangesAsync();
        }
        #endregion

        #region Update Common Fields
        private void UpdatePropertiesBeforeSave(string userId = null)
        {
            //if (string.IsNullOrEmpty(userId)
            //       && HttpContext.Current != null
            //       && HttpContext.Current.User != null
            //       && HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    userId = HttpContext.Current.User.Identity.Name;
            //}

            const string CreatedOnProperty = "CreatedOn";
            const string ModifiedOnPropery = "UpdatedOn";
            // const string IsActiveProperty = "IsActive";
            const string IdProperty = "Id";

            IEnumerable<EntityEntry> entitiesWithCreatedOn =
                this.Context.ChangeTracker.Entries()
                    .Where(
                        e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(CreatedOnProperty) != null);
            foreach (EntityEntry entry in entitiesWithCreatedOn)
            {
                entry.Property(CreatedOnProperty).CurrentValue = DateTime.Now;
            }

            //IEnumerable<DbEntityEntry> entitiesWithStateCode =
            //    this.context.ChangeTracker.Entries()
            //        .Where(
            //            e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(IsActiveProperty) != null);
            //foreach (DbEntityEntry entry in entitiesWithStateCode)
            //{
            //    entry.Property(IsActiveProperty).CurrentValue = true;
            //}

            IEnumerable<EntityEntry> entitiesWithId =
                this.Context.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added && e.Entity.GetType().GetProperty(IdProperty) != null);
            foreach (EntityEntry entry in entitiesWithId)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(entry.Property(IdProperty).CurrentValue.ToString(), out id) && id == Guid.Empty)
                {
                    entry.Property(IdProperty).CurrentValue = Guid.NewGuid();
                }
            }

            IEnumerable<EntityEntry> entitiesWithModifiedOn =
                this.Context.ChangeTracker.Entries()
                    .Where(
                        e => e.State == EntityState.Modified && e.Entity.GetType().GetProperty(ModifiedOnPropery) != null);
            foreach (EntityEntry entry in entitiesWithModifiedOn)
            {
                entry.Property(ModifiedOnPropery).CurrentValue = DateTime.Now;
            }

            if (!string.IsNullOrEmpty(userId))
            {
                const string CreatedByPropery = "CreatedBy";
                const string ModifiedByPropery = "UpdatedBy";
                IEnumerable<EntityEntry> entitiesWithCreatedBy =
                     this.Context.ChangeTracker.Entries()
                        .Where(
                            e =>
                            e.State == EntityState.Added && e.Entity.GetType().GetProperty(CreatedByPropery) != null);
                foreach (EntityEntry entry in entitiesWithCreatedBy)
                {
                    entry.Property(CreatedByPropery).CurrentValue = userId;
                }

                IEnumerable<EntityEntry> entitiesWithModifiedBy =
                    this.Context.ChangeTracker.Entries()
                        .Where(
                            e =>
                            e.State == EntityState.Modified && e.Entity.GetType().GetProperty(ModifiedByPropery) != null);
                foreach (EntityEntry entry in entitiesWithModifiedBy)
                {
                    entry.Property(ModifiedByPropery).CurrentValue = userId;
                }
            }
        }
        #endregion

        #region Disposing

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
