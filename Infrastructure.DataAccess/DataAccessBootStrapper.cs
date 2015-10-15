using Core.Model.Offers;
using Core.Model.Users;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.Domain;
using Infrastructure.Domain.DataInterfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public static class DataAccessBootStrapper
    {
        public static void Initialize(IContainer container)
        {
            NHibernateSession.InitStorage(new SimpleSessionStorage());
            NHibernateSession.InitSessionFactoryManager(new SessionFactoryManager(new DataAccessFactoryBuilder()));

            container.Register<ISessionFactory>(NHibernateSession.GetSessionFactory);
            container.Register<ISession>(() => NHibernateSession.Current);
            container.Register<IUserRepository, UserRepository>();
            container.Register<IRepository<Offer,Guid>, Repository<Guid,Offer>>();
            container.Register<IRepository<Core.Model.Property.Property, Guid>, Repository<Guid, Core.Model.Property.Property>>();

            container.Register<IDbContextProvider, DBContextProvider>();
            container.Register<DBContextProvider>(() => new DBContextProvider());
        }
    }
}
