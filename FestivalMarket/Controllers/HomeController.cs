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
    public class HomeController : Controller
    {
        private ApplicationDbContext db =  new ApplicationDbContext();
        public ActionResult Index(string slugName)
        {
            if (slugName != null)
            {
                var data = db.News.Where(x => x.Slug == slugName).FirstOrDefault();
                if (data != null)
                {
                    /*ViewBag.viewnewID = db.News.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();*/
                    ViewBag.prodetails = data;
                    return View("DetailNews", data);
                }
                else
                {
                    var data1 = db.Product.Where(x => x.Slug == slugName).FirstOrDefault();
                    if (data1 != null)
                    {
                        
                        return View("DetailPro", data1);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();
        }

        public ActionResult GetBanner()
        {
            var item = db.Slides.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(1).FirstOrDefault();
            ViewBag.getBanner = item;
            return PartialView(item);
        }
        public ActionResult GetListEvents()
        {
            var items = db.Events.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();
            return PartialView(items);
        }
        public ActionResult GetListNews()
        {
            var items = db.News.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();

            return PartialView(items);
        }
        public ActionResult GetListSales()
        {
            var items = db.Sales.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(1).FirstOrDefault();
            ViewBag.ListSales = items;
            return PartialView(items);
        }
        public ActionResult GetListSalesOfViews()
        {
            var items = db.Sales.Where(x => x.IsActive == 1 ).OrderByDescending(x => x.Views).Take(3).ToList();
          
            return PartialView(items);
        }
        public ActionResult GetListProduct()
        {
            var items = db.Product.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3);
          
            return PartialView(items);
        }
        public ActionResult GetListProductOfViews()
        {
            var items = db.Product.Where(x => x.IsActive == 1).OrderByDescending(x => x.Views).Take(1).FirstOrDefault();
            ViewBag.ListPro = items;
            return PartialView(items);
        }

        public ActionResult GetListFilms(int? id)
        {
            var items = db.FilmsView.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();

            if (id > 0)
            {
                items = items.Where(n => n.CategoryFilmId == id).ToList();

            }
            /*   ViewBag.news = items;*/

            ViewBag.CateId = id;
            return PartialView(items);
        }
        public ActionResult DetailFilms(string alias, int id)
        {
            var items = db.FilmsView.Find(id);
            ViewBag.salessview = items;
            if (ViewBag.salessview != null)
            {
                db.FilmsView.Attach(items);
                items.Views = items.Views + 1;
                db.Entry(items).Property(x => x.Views).IsModified = true;
                db.SaveChanges();
            }


            return View();

        }
        public ActionResult Partial_FilmsId()
        {
            var items = db.FilmsView.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
            return PartialView(items);
        }
    }
}