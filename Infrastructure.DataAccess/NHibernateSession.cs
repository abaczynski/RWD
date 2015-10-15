using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public static class NHibernateSession
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionStorage _sessionStorage;
        private static ISessionFactoryManager _sessionFactoryManger;

        public static ISession Current
        {
            get
            {
                var session = _sessionStorage.GetSession();
                if (session == null || session.IsOpen == false)
                {
                    session = GetSessionFactory().OpenSession();

                    _sessionStorage.SetSession(session);
                }
                return session;
            }
        }

        public static void InitStorage(ISessionStorage storage)
        {
            _sessionStorage = storage;
        }
        public static void InitSessionFactory(ISessionFactory factory)
        {
            _sessionFactory = factory;
        }
        public static void InitSessionFactoryManager(ISessionFactoryManager sessionFactoryManager)
        {
            _sessionFactoryManger = sessionFactoryManager;
        }

        public static bool IsSessionFactoryInitialized()
        {
            return _sessionFactory != null;
        }

        public static ISessionFactory GetSessionFactory()
        {
            return _sessionFactory ?? _sessionFactoryManger.GetCurrentFactory();
        }

        public static void ClearSession()
        {
            _sessionStorage.SetSession(null);
        }

        public static ISession GetCurrentSession()
        {
            return Current;
        }
    }

    public interface ISessionStorage
    {
        ISession GetSession();
        void SetSession(ISession session);
    }
}
