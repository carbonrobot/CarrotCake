namespace CarrotCake.Data.Ef.Extensions
{
    using System;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using Domain;

    public static class DbContextExtensions
    {
        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <param name="context">The data context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>TContext.</returns>
        public static EFDataContext Attach<T>(this EFDataContext context, T entity) where T : class, IEntity
        {
            context.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
            return context;
        }

        /// <summary>
        /// Provides a statically typed interface for db includes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="set">The set.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>DbSet&lt;T&gt;.</returns>
        public static DbSet<T> Include<T>(this DbSet<T> set, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            if (includes != null)
            {
                foreach (var expression in includes)
                {
                    set.Include(expression);
                }
            }
            return set;
        }
    }
}