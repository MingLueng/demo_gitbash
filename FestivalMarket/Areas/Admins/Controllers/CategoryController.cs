using FestivalMarket.Common;
using FestivalMarket.Models;
using FestivalMarket.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace FestivalMarket.Areas.Admins.Controllers
{
    public class CategoryController : Controller
    {
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
            var data = db.Category.OrderBy(x => x.Order).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region " Add/Update/Delete"
        [HttpPost]
        public JsonResult AddOrUpdate(Category itemInfor)
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
                Category item = itemInfor as Category;
                if (itemInfor.CreatedDate == null)
                    itemInfor.CreatedDate = DateTime.Now;
                if (item.ModifiedDate == null)
                    item.ModifiedDate = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }

            var data = db.Category.OrderBy(x => x.Order).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteByID(int id)
        {
            try
            {
                var data = db.News.Where(x => x.CategoryId == id).FirstOrDefault();
                if (data != null)
                {
                    return Json(2, JsonRequestBehavior.AllowGet);
                }
                Category item = db.Category.Find(id);
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