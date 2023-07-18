using FestivalMarket.Models.EF;
using FestivalMarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalMarket.Areas.Admins.Controllers
{
    public class FilmsController : Controller
    {
        // GET: Admins/Flims
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admins/News
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lấy ra tất cả các sản phẩm
        /// </summary>
        /// <param name="cid"> Mã loại sản phẩm</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDataJSON(int? cid)
        {
            var data = (from n in db.FilmsView
                        join c in db.CategoryFilm on n.CategoryFilmId equals c.Id
                        select new
                        {
                            Id = n.Id,
                            Code = n.Code,
                            Title = n.Title,
                            TenDMTinTuc = c.Title,
                            NewCateId = c.Id,
                            Image = n.Image,
                            Description = n.Description,
                            Detail = n.Detail,
                            Slug = n.Slug,
                            Alias = n.Alias,
                            Views = n.Views,
                            CategoryFilmId = n.CategoryFilmId,
                            CreatedDate = n.CreatedDate,
                            ModifiedDate = n.ModifiedDate
                        }).OrderByDescending(x => x.ModifiedDate).ToList();

            if (cid != null)
            {
                data = data.Where(x => x.CategoryFilmId == cid).ToList();
            }
            data = data.OrderByDescending(x => x.ModifiedDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.CategoryFilm.Where(x => x.IsActive == 1).OrderBy(x => x.Order).ToList();

            return PartialView();
        }
        public ActionResult Edit(int id)
        {
            var data = db.FilmsView.Find(id);
            ViewBag.Categories = db.CategoryFilm.Where(x => x.IsActive == 1).OrderBy(x => x.Order).ToList();

            return PartialView(data);
        }


        [HttpPost]
        public JsonResult AddOrUpdate(FilmsView news)
        {
            /*  if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet); ;*/
            if (news.Id == 0)
            {
                news.CreatedDate = DateTime.Now;
                news.ModifiedDate = DateTime.Now;
                news.Views = news.Likes = 0;
                db.FilmsView.Add(news);
                db.Entry(news).State = EntityState.Added;
                db.SaveChanges();
                var result = db.FilmsView.OrderByDescending(x => x.Id).FirstOrDefault();


                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }


            news.ModifiedDate = DateTime.Now;
            db.Entry(news).State = EntityState.Modified;



            db.SaveChanges();



            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteByID(int id)
        {
            try
            {

                FilmsView item = db.FilmsView.Find(id);

                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
    }
}