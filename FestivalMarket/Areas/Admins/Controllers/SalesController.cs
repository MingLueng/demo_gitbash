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
    public class SalesController : Controller
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
            var data = db.Sales.ToList();
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
            var data = db.Sales.Find(id);
            /*ViewBag.Categories = db.Category.Where(x => x.IsActive).OrderBy(x => x.Order).ToList();*/

           /* ViewBag.images = db.EventsImage.Where(x => x.EventsId == id).ToList();*/



            return PartialView(data);
        }
       /* public ActionResult ListMaterial()
        {

            return PartialView();
        }*/

        [HttpPost]
        public JsonResult AddOrUpdate(Sales eve)
        {
            /*if (!ModelState.IsValid) return Json(0, JsonRequestBehavior.AllowGet); */
            if (eve.Id == 0)
            {
                eve.CreatedDate = DateTime.Now;
                eve.ModifiedDate = DateTime.Now;
                eve.Views = eve.Likes = 0;
                db.Sales.Add(eve);
                db.Entry(eve).State = EntityState.Added;
                db.SaveChanges();
                var result = db.Sales.OrderByDescending(x => x.Id).FirstOrDefault();


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
                Sales item = db.Sales.Find(id);

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