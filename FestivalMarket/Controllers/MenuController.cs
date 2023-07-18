using FestivalMarket.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalMarket.Models.EF;

namespace FestivalMarket.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.Category.ToList();
            return PartialView("_MenuTop", items);

        }
        public ActionResult MenuArrival(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
        
            var items = db.Category.ToList();
            return PartialView("_MenuArrival", items);
        }
    }
}