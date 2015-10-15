using Core.Model.Users;
using PurpleBricksDemo.Web.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleBricksDemo.Web.Services
{
    public class SessionStorage : ISessionStorage
    {
        private readonly IUserService _systemUserService;
        public SessionStorage(IUserService systemUserService)
        {
            _systemUserService = systemUserService;

        }


        public User CurrentSystemUser
        {
            get
            {
                var currentUser = HttpContext.Current.Session["SystemUser"] as User;
                if (currentUser != null)
                    return currentUser;

                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    var user = _systemUserService.GetUserById(new Guid(HttpContext.Current.User.Identity.Name));
                    HttpContext.Current.Session["SystemUser"] = user;

                    return user;
                }

                return null;
            }
            set { HttpContext.Current.Session["SystemUser"] = value; }
        }
    }
}