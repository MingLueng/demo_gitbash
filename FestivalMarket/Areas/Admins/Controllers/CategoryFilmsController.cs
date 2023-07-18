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
    public class CategoryFilmsController : Controller
    {
        // GET: Admins/CategoryFilms
        // GET: Admins/Category
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý danh mục sản phẩm";
            return View();
        }

        [HttpPost]
        public JsonResult GetDataJSON()
        {
            var data = db.CategoryFilm.OrderBy(x => x.Order).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region " Add/Update/Delete"
        [HttpPost]
        public JsonResult AddOrUpdate(CategoryFilm itemInfor)
        {
            if (itemInfor.Id == 0)
            {
                if (itemInfor.CreatedDate == null)
                    itemInfor.CreatedDate = DateTime.Now;
                itemInfor.ModifiedDate = DateTime.Now;
                db.Entry(itemInfor).State = EntityState.Added;
                db.SaveChanges();
            }
            else
            {
                CategoryFilm item = itemInfor as CategoryFilm;
                if (itemInfor.CreatedDate == null)
                    itemInfor.CreatedDate = DateTime.Now;
                if (item.ModifiedDate == null)
                    item.ModifiedDate = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }

            var data = db.CategoryFilm.OrderBy(x => x.Order).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteByID(int id)
        {
            try
            {
                var data = db.FilmsView.Where(x => x.CategoryFilmId == id).FirstOrDefault();
                if (data != null)
                {
                    return Json(2, JsonRequestBehavior.AllowGet);
                }
                CategoryFilm item = db.CategoryFilm.Find(id);
                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
    }
}
