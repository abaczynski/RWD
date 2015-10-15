using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurpleBricksDemo.Web.Models.Sessions
{
    public interface IAuthentication
    {
        void Logout();
        void Login(string userId, bool rememberMe);
        Guid GetCurrentUserId();
    }
}
