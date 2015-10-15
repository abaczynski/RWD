using Infrastructure.Domain.DataInterfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class DBContextProvider : IDbContextProvider
    {
        public virtual ISession CurrentSession
        {
            get { return NHibernateSession.Current; }
        }

        public IDbContext CurrentContext
        {
            get
            {

                return new DbContext(NHibernateSession.Current);
            }
        }
    }
}
