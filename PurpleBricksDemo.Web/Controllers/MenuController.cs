using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurpleBricksDemo.Web.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
   
        public ActionResult NavigationMenu()
        {
            return PartialView();
        }

    }
}
