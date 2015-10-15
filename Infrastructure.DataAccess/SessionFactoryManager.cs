using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Infrastructure.DataAccess
{
    public class SessionFactoryManager : ISessionFactoryManager
    {
        private readonly IDataAccessFactoryBuilder _dataAccessFactoryBuilder;

        public SessionFactoryManager(IDataAccessFactoryBuilder dataAccessFactoryBuilder)
        {
            _dataAccessFactoryBuilder = dataAccessFactoryBuilder;
        }

        public ISessionFactory GetCurrentFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PurpleBricks"].ConnectionString;

            //string connectionString = @"Server=tcp:idkw0kf851.database.windows.net,1433;Database=rwdcarsAKhefKQPs;User ID=baczynski.a@gmail.com@tmlar4jnxa@idkw0kf851;Password=Lolada123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            ISessionFactory sessionFactory = _dataAccessFactoryBuilder.BuildSessionFactory(connectionString);
            return sessionFactory;
        }
    }
}
