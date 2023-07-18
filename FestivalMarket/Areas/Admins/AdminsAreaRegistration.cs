using System.Web.Mvc;

namespace FestivalMarket.Areas.Admins
{
    public class AdminsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
               "category",
               "admins/category/{action}/{id}",
               new { AreaName = "Admins", controller = "Category", action = "Index", id = UrlParameter.Optional },
               new string[] { "FestivalMarket.Areas.Admins.Controllers" }
            );
         
            /*context.MapRoute(
               "extension",
               "admins/extension/{id}",
               new { AreaName = "Admins", controller = "EXTENSIONS", action = "Index", id = UrlParameter.Optional },
               new string[] { "FestivalMarket.Areas.Admins.Controllers" }
            );*/
            //context.MapRoute(
            //   "materials",
            //   "admins/materials/{id}",
            //   new { AreaName = "Admins", controller = "MATERIALS", action = "Index", id = UrlParameter.Optional },
            //   new string[] { "DevApps.Areas.Admins.Controllers" }
            //);
            context.MapRoute(
                "Admins_default",
                "Admins/{controller}/{action}/{id}",
                new { AreaName = "Admins", Controller = "Admins", action = "Index", id = UrlParameter.Optional },
                new string[] { "FestivalMarket.Areas.Admins.Controllers" }
            );
        }
    }
}