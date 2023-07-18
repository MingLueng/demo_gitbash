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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.lstNewPro = db.Product.Where(x => x.IsActive == 1 && x.Highlight == false).OrderByDescending(x => x.ModifiedDate).Take(1).FirstOrDefault();
            return View();
        }

        public ActionResult Partial_ItemCateId()
        {
            var items = db.Product.Where(x => x.IsActive == 1 && x.Highlight == true).OrderByDescending(x => x.ModifiedDate).Take(4).ToList();
            return PartialView(items);
        }
       

        public ActionResult Partial_ViewPro()
        {
            var items = db.Product.Where(x => x.IsActive == 1 && x.Highlight == true).OrderByDescending(x => x.Views).Take(4).ToList();
            return PartialView(items);
        }

        public ActionResult GetNewsHot()
        {
            var items = db.Product.Where(x => x.IsActive == 1 && x.Highlight == false).OrderByDescending(x => x.ModifiedDate).Take(1).FirstOrDefault();
            ViewBag.lstNewsPro = items;
            return PartialView(items);
        }
        public ActionResult Partial_HotPro()
        {
            var items = db.Product.Where(x => x.IsActive == 1 && x.Highlight == false).OrderByDescending(x => x.ModifiedDate).Take(4).ToList();
            return PartialView(items);
        }
        public ActionResult DetailPro(string alias, int id)
        {
            var items = db.Product.Find(id);
            ViewBag.productview = items;
            if (ViewBag.productview != null)
            {
                db.Product.Attach(items);
                items.Views = items.Views + 1;
                db.Entry(items).Property(x => x.Views).IsModified = true;
                db.SaveChanges();
            }


            return View();

        }
        public ActionResult Partial_ProductId()
        {
            var items = db.Product.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
            return PartialView(items);
        }
    }
}