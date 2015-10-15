using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess
{
    public class SimpleSessionStorage : ISessionStorage
    {
        [ThreadStatic]
        private static ISession _session;

        public ISession GetSession()
        {
            return _session;
        }

        public void SetSession(ISession session)
        {

            _session = session;
        }
    }
}
