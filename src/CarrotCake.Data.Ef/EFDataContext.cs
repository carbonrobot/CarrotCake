namespace CarrotCake.Data.Ef
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using Extensions;

    public class EFDataContext : DbContext, IDataContext
    {
        public EFDataContext()
        {
            // Disable auto creation
            Database.SetInitializer<EFDataContext>(null);

            // Turn off auto detect and lazy loading
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns>True if successful</returns>
        public bool Delete<T>(int id) where T : class, IEntity
        {
            var entity = this.Set<T>().Find(id);
            return this.Delete(entity);
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        public bool Delete<T>(T entity) where T : class, IEntity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can not be null when calling delete(entity)");

            this.Set<T>().Remove(entity);
            return this.SaveChanges() > 0;
        }

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        public T Find<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).Find(id);
        }

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        public T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).Find(id);
        }

        /// <summary>
        /// Returns a complete list of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes">The includes.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> List<T>(params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).ToList();
        }

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The updated entity</returns>
        public T Save<T>(T entity) where T : class, IEntity
        {
            this.Attach(entity);
            this.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Shortcut method for the IQueryable interface method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public IList<T> Where<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            return this.Set<T>().Include(includes).Where(predicate).ToList();
        }
    }
}