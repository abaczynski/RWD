using System.Web.Mvc;

namespace PurpleBricksDemo.Web.Areas.Buyer
{
    public class BuyerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Buyer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Buyer_default",
                "Buyer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
