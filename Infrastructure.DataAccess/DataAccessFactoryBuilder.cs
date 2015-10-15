using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class DataAccessFactoryBuilder : IDataAccessFactoryBuilder
    {
        private static ISessionFactory _dataAccessSessionFactory;

        public ISessionFactory DataAccessFactory
        {
            get
            {

                var connectionString = @"Server=MARCIN-TOSH8\LOCALDB; Database=RWD; Integrated Security=SSPI;";

                _dataAccessSessionFactory = BuildSessionFactory(connectionString);

                return _dataAccessSessionFactory;
            }
        }

        public ISessionFactory BuildSessionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string can't be null or empty");
            var config = Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DbContext>())
                .BuildConfiguration();

            var exporter = new SchemaExport(config);
            //exporter.Execute(true, true, false);

            return config.BuildSessionFactory();
        }
    }
}
