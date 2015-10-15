using Infrastructure.Domain;
using Infrastructure.Domain.DataInterfaces;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.DataAccess.Repositories
{
    public class Repository<TId, T> : IRepository<T, TId> where T : Entity<TId>
    {
        private readonly DBContextProvider _contextProvider;

        public Repository(DBContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public Repository()
        {
            
        }

        protected virtual ISession Session
        {
            get { return _contextProvider.CurrentSession; }
        }

        public virtual IDbContext DbContext
        {
            get { return _contextProvider.CurrentContext; }
        }

        public virtual T Get(TId id)
        {
            return Session.Get<T>(id);
        }

        public virtual T1 Get<T1>(TId id) where T1 : T
        {
            return Session.Get<T1>(id);
        }

        public IEnumerable<T1> Get<T1>(Expression<Func<T1, bool>> expression) where T1 : T
        {
            return Session.Query<T1>().Where(expression);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual T SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public void Refresh(T entity)
        {
            Session.Flush();
            Session.Refresh(entity);
        }

        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return Session.Query<T>().Where(expression);
        }
    }
}
