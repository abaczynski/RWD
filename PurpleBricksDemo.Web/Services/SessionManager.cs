using PurpleBricksDemo.Web.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleBricksDemo.Web.Services
{
    public class SessionManager : ISessionManager
    {
        private readonly ISessionStorage _sessionStorage;

        public SessionManager(ISessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public ISessionStorage CurrentSession { get { return _sessionStorage; } }


    }
}