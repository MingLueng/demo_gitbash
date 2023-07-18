using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalMarket.Models;
using FestivalMarket.Models.EF;
using PagedList;
using System.Web.UI;

namespace FestivalMarket.Controllers
{
    public class NewSalesController : Controller

    {
        // GET: Sales
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.lstNewSales = db.Sales.Where(x =>x.IsActive==1).OrderByDescending(x => x.ModifiedDate).Take(1).FirstOrDefault();
            return View();
        }
        public ActionResult Partial_NewSales(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Sales> items = db.Sales.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return PartialView(items);
            
            
        }

        public ActionResult Partial_ViewNew()
        {
            var items = db.Sales.Where(x => x.IsActive==1).OrderByDescending(x =>x.Views).Take(4).ToList();
            return PartialView(items);
        }
        public ActionResult DetailSales(string alias, int id)
        {
            var items = db.Sales.Find(id);
            ViewBag.salessview = items;
            if (ViewBag.salessview != null)
            {
                db.Sales.Attach(items);
                items.Views = items.Views + 1;
                db.Entry(items).Property(x => x.Views).IsModified = true;
                db.SaveChanges();
            }


            return View();

        }
        public ActionResult Partial_SalesId()
        {
            var items = db.Sales.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
            return PartialView(items);
        }
    }
}