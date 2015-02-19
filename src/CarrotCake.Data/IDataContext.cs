namespace CarrotCake.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Domain;

    public interface IDataContext : IDisposable
    {
        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns>True if successful</returns>
        bool Delete<T>(int id) where T : class, IEntity;

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        bool Delete<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        T Find<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <param name="includes">The includes.</param>
        /// <returns>T.</returns>
        T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Returns a complete list of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes">The includes.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> List<T>(params Expression<Func<T, object>>[] includes) where T : class, IEntity;

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>The updated entity</returns>
        T Save<T>(T entity) where T : class, IEntity;

        /// <summary>
        /// Returns a filtered list of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IList<T> Where<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity;
    }
}