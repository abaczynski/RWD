using Core.Model.Users;
using PurpleBricksDemo.Web.Models.Account;
using PurpleBricksDemo.Web.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PurpleBricksDemo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;
        private readonly ISessionManager _sessionManager;
        private readonly IUserService _userService;

        public AccountController(IAuthentication authentication, ISessionManager sessionManager, IUserService userService) {
            _authentication = authentication;
            _sessionManager = sessionManager;
            _userService = userService;
        }

        public ActionResult LogOn()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(new LogOnViewModel());
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel logOnViewModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(logOnViewModel.Username, logOnViewModel.Password))
                {
                    _authentication.Login(_sessionManager.CurrentSession.CurrentSystemUser.Id.ToString(), logOnViewModel.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }
            return View("LogOn", logOnViewModel);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel newUser)
        {
            if(ModelState.IsValid){
                try {

                    _userService.CreateUser(newUser.Username, newUser.Password, newUser.UserRole);

                    if (Membership.ValidateUser(newUser.Username, newUser.Password))
                    {
                        _authentication.Login(_sessionManager.CurrentSession.CurrentSystemUser.Id.ToString(), false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (ArgumentException e) {
                    ModelState.AddModelError("", e.Message);
                }
                
            }
            return View(newUser);
        }


        public ActionResult CreateUser()
        {
            return PartialView(new CreateUserViewModel());
        }

        public RedirectToRouteResult LogOut()
        {
            _authentication.Logout();
            return RedirectToAction("LogOn");
        }

    }
}
