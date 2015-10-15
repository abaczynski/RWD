using Infrastructure.Domain.DataInterfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class DbContext : IDbContext
    {
        private readonly ISession _session;

        public DbContext(ISession session)
        {
            _session = session;
        }

        public virtual IDisposable BeginTransaction()
        {
            return _session.BeginTransaction();
        }


        public virtual void CommitChanges()
        {
            _session.Flush();
        }

        public virtual void CommitTransaction()
        {
            _session.Transaction.Commit();
        }

        public virtual void RollbackTransaction()
        {
            _session.Transaction.Rollback();
        }
    }
}
