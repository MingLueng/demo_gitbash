using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FestivalMarket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
            routes.MapRoute(
               name: "Trang chủ",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", alias = UrlParameter.Optional },
               namespaces: new[] { "FestivalMarket.Controllers" }
              );
                    routes.MapRoute(
                             name: "Tin tức",
                             url: "tin-tuc",
                             defaults: new { controller = "News", action = "IndexNew", alias = UrlParameter.Optional },
                             namespaces: new[] { "FestivalMarket.Controllers" }
                             );
            routes.MapRoute(
                        name: "DetailNews",
                        url: "chi-tiet/{slug}-{id}",
                        defaults: new { controller = "News", action = "DetailNews", alias = UrlParameter.Optional },
                        namespaces: new[] { "FestivalMarket.Controllers" }
                    );
            routes.MapRoute(
             name: "Khuyến mại",
             url: "khuyen-mai",
             defaults: new { controller = "NewSales", action = "Index", alias = UrlParameter.Optional },
             namespaces: new[] { "FestivalMarket.Controllers" }
            );
            routes.MapRoute(
name: "DetailSales",
url: "chi-tiet-sales/{slug}-{id}",
defaults: new { controller = "NewSales", action = "DetailSales", alias = UrlParameter.Optional },
namespaces: new[] { "FestivalMarket.Controllers" }
);
            routes.MapRoute(
                     name: "Sự kiện",
                     url: "su-kien",
                     defaults: new { controller = "Events", action = "Index", alias = UrlParameter.Optional },
                     namespaces: new[] { "FestivalMarket.Controllers" }
                     );
            routes.MapRoute(
name: "DetailEvents",
url: "chi-tiet-events/{slug}-{id}",
defaults: new { controller = "Events", action = "DetailEvents", alias = UrlParameter.Optional },
namespaces: new[] { "FestivalMarket.Controllers" }
);
            routes.MapRoute(
                  name: "Thành viên",
                  url: "thanh-vien",
                  defaults: new { controller = "MemberIntro", action = "Index", alias = UrlParameter.Optional },
                  namespaces: new[] { "FestivalMarket.Controllers" }
                  );
            routes.MapRoute(
   name: "DetailFilms",
url: "chi-tiet-films/{slug}-{id}",
defaults: new { controller = "Home", action = "DetailFilms", alias = UrlParameter.Optional },
namespaces: new[] { "FestivalMarket.Controllers" }
);

            routes.MapRoute(
                         name: "FestivalGo",
                         url: "festival-go",
                         defaults: new { controller = "Product", action = "Index", alias = UrlParameter.Optional },
                         namespaces: new[] { "FestivalMarket.Controllers" }
                        );
            routes.MapRoute(
name: "DetailPro",
url: "chi-tiet-products/{slug}-{id}",
defaults: new { controller = "Product", action = "DetailPro", alias = UrlParameter.Optional },
namespaces: new[] { "FestivalMarket.Controllers" }
);
            routes.MapRoute(
                 name: "Liên hệ",
                 url: "lien-he",
                 defaults: new { controller = "Contact", action = "Index", alias = UrlParameter.Optional },
                 namespaces: new[] { "FestivalMarket.Controllers" }
                 );

            routes.MapRoute(
                            name: "Chi tiết danh mục",
                            url: "tin-tuc/{id}",
                            defaults: new { controller = "News", action = "Index", alias = UrlParameter.Optional },
                            namespaces: new[] { "FestivalMarket.Controllers" }
                            );
   
            routes.MapRoute(
                           name: "Default",
                           url: "{controller}/{action}/{id}",
                           defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                           namespaces: new[] { "FestivalMarket.Controllers" }
                       );


        }
    }
}
