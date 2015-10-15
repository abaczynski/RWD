using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using System.Web.Mvc;
using NHibernate.Linq;
using Core.Model.Users;
using PurpleBricksDemo.Web.Models.Sessions;

namespace PurpleBricksDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionStorage _sessionStorage;

        public HomeController(IUserService userService, ISessionStorage sessionStorage) {
            _userService = userService;
            _sessionStorage = sessionStorage;
        }
        [Authorize]
        public ActionResult Index()
        {
            if(User.IsInRole("Buyer"))
                return RedirectToAction("Index", "Default", new { area = "Buyer" });

            if (User.IsInRole("Seller"))
                return RedirectToAction("Index", "Default", new { area = "Seller" });

            //var user2 = _userService.CreateUser("test3", "test4");
            return View();
        }


    }
}
