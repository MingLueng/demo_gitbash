using FestivalMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FestivalMarket.Models.EF;
using PagedList;
using System.Web.UI;
using System.Net;

namespace FestivalMarket.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            
            return View();
        }

     
        public ActionResult Partial_News(int? id)
        {
            var items = db.News.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();

            if (id > 0)
            {
                items = items.Where(n => n.CategoryId == id).Take(3).ToList();

            }
         /*   ViewBag.news = items;*/
           
            ViewBag.CateId = id;
            return PartialView(items);
        }
        public ActionResult Partial_ShowNews(int? id,int? page)
        {
           
            var pageSize = 8;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = db.News.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();
            if (id > 0)
            {
                items = items.Where(n => n.CategoryId == id).ToList();

            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
          



            return PartialView(items);
        }

        public ActionResult Partial_ViewNews()
        {
            var items = db.News.Where(x => x.IsActive == 1).OrderByDescending(x => x.Views).Take(4).ToList();
            ViewBag.NewsView = items;
            return PartialView(items);
        }

        public ActionResult IndexNew()
        {

            return View();
        }
        public ActionResult Promitment_News()
        {     
            try
            {
                var items = db.News.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(1).ToList();
                ViewBag.TinMoi = items;
                return PartialView (new { success = true, msg = "Bạn đã lưu thành công bản ghi này" });

            }
            catch(Exception ex)
            {
                return View(new { success = false, msg = "Bạn đã lưu thất bại" + ex.Message });
            }
            
        }
        public ActionResult Partial_MoiNhat()
        {
            var items = db.News.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
          /*  ViewBag.MoiNhat = items;*/
            return PartialView(items);
        }
        public ActionResult Partial_TinMoi(int? page)
        {
            var pageSize = 8;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = db.News.Where(x => x.IsActive == 1).OrderByDescending(x => x.ModifiedDate).ToList();
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
       /*     ViewBag.TinMoiNhat = items;*/
            return PartialView(items);
        }

        public ActionResult DetailNews(string alias, int id, int? procateid)
        {
            var data = db.News.Find(id);
            ViewBag.prodetails = data;
            if (ViewBag.prodetails != null)
            {
                db.News.Attach(data);
                data.Views = data.Views + 1;
                db.Entry(data).Property(x => x.Views).IsModified = true;
                db.SaveChanges();
            }


            return View();

        }

        public ActionResult Partial_NewId()
        {
            var items = db.News.Where(n => n.IsActive == 1).OrderByDescending(x => x.ModifiedDate).Take(3).ToList();
/*
            if (id > 0)
            {
                items = items.Where(n => n.CategoryId == id).Take(3).ToList();

            }
            ViewBag.news = items;

            ViewBag.CateId = id;*/
            return PartialView(items);
        }

    }
}