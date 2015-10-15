using PurpleBricksDemo.Web.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PurpleBricksDemo.Web.Infrastructure
{
    public class FormsAuthentication : IAuthentication
    {
        public void Logout()
        {
            HttpContext.Current.Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            HttpCookie httpCookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, "");
            httpCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public void Login(string userId, bool rememberMe)
        {
            DateTime expiryDate = rememberMe ? DateTime.Now.AddMonths(30) : DateTime.Now.AddMinutes(30);

            HttpContext.Current.Response.Cookies.Remove(System.Web.Security.FormsAuthentication.FormsCookieName);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, userId, DateTime.Now, expiryDate, true, String.Empty);
            string encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
            HttpCookie authenticationCookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encryptedTicket);
            authenticationCookie.Expires = ticket.Expiration;
            HttpContext.Current.Response.Cookies.Add(authenticationCookie);
        }

        public Guid GetCurrentUserId()
        {
            Guid userId = new Guid(Membership.GetUser().UserName);
            return userId;
        }
    }
}