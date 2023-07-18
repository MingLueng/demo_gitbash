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
    public class MemberIntroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admins/PRODUCTS
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
        public JsonResult GetDataJSON()
        {
            var data = db.Introduction.ToList();
            data = data.OrderByDescending(x => x.ModifiedDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            /*  ViewBag.Categories = db.Category.Where(x => x.IsActive).OrderBy(x => x.Order).ToList();*/

            return PartialView();
        }
        public ActionResult Edit(int id)
        {
            var data = db.Introduction.Find(id);
            /*ViewBag.Categories = db.Category.Where(x => x.IsActive).OrderBy(x => x.Order).ToList();*/

            /* ViewBag.images = db.EventsImage.Where(x => x.EventsId == id).ToList();*/



            return PartialView(data);
        }
        /* public ActionResult ListMaterial()
         {

             return PartialView();
         }*/

        [HttpPost]
        public JsonResult AddOrUpdate(Introduction eve)
        {
            /*if (!ModelState.IsValid) return Json(0, JsonRequestBehavior.AllowGet); */
            if (eve.Id == 0)
            {
                eve.CreatedDate = DateTime.Now;
                eve.ModifiedDate = DateTime.Now;
                eve.Views = eve.Likes = 0;
                db.Introduction.Add(eve);
                db.Entry(eve).State = EntityState.Added;
                db.SaveChanges();
                var result = db.Introduction.OrderByDescending(x => x.Id).FirstOrDefault();


                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }


            eve.ModifiedDate = DateTime.Now;
            db.Entry(eve).State = EntityState.Modified;



            db.SaveChanges();



            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteByID(int id)
        {
            try
            {
                Introduction item = db.Introduction.Find(id);

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