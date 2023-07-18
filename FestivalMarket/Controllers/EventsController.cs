using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using FestivalMarket.Models;
using FestivalMarket.Models.EF;
using PagedList;

namespace FestivalMarket.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Events
        public ActionResult Index()
        {
            ViewBag.lstNewEvents = db.Events.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(1).FirstOrDefault();
            return View();
        }
        public ActionResult Partial_NewEvents()
        {
            var items = db.Events.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(4).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ShowEvents(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Events> items = db.Events.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
          
            return PartialView(items);
        }

        public ActionResult DetailEvents(string alias, int id)
        {
            var items = db.Events.Find(id);
            ViewBag.eventsview = items;
            if (ViewBag.eventsview != null)
            {
                db.Events.Attach(items);
                items.Views = items.Views + 1;
                db.Entry(items).Property(x => x.Views).IsModified = true;
                db.SaveChanges();
            }


            return View();

        }
        public ActionResult Partial_EventsId()
        {
            var items = db.Events.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
            return PartialView(items);
        }

    }
}