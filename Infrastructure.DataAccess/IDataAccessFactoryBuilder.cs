using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public interface IDataAccessFactoryBuilder
    {
        ISessionFactory BuildSessionFactory(string connectionString);
    }
}
