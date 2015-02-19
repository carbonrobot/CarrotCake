namespace CarrotCake.Data.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Linq;
    using Domain;

    public class SqlDataContext : IDataContext
    {
        public bool Delete<T>(int id) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(T entity) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> List<T>(params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public T Save<T>(T entity) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public IList<T> Where<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class, IEntity
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
