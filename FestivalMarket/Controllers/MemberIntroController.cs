using FestivalMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FestivalMarket.Models.EF;
namespace FestivalMarket.Controllers
{
    public class MemberIntroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: MemberIntro
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMemberIntro()
        {
            var items = db.Introduction.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(5).ToList();
            ViewBag.lstSlides = items;
            return PartialView(items);
    }
    }
}