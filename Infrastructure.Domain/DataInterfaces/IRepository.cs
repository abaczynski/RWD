using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Domain.DataInterfaces
{
    public interface IRepository<T, in TId> where T : Entity<TId>
    {
        IDbContext DbContext { get; }

        T Get(TId id);

        IQueryable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> expression);

        T SaveOrUpdate(T entity);
        void Refresh(T entity);

        void Delete(T entity);
    }
}
