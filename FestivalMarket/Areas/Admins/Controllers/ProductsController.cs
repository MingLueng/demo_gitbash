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
    public class ProductsController : Controller
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
            var data = (from n in db.Product
                        select new
                        {
                            Id = n.Id,
                            Code = n.Code,
                            Title = n.Title,
                            Image = n.Image,

                            Description = n.Description,
                            Detail = n.Detail,
                            Slug = n.Slug,
                            Alias = n.Alias,
                            Views = n.Views,
                            CreatedDate = n.CreatedDate,
                            ModifiedDate = n.ModifiedDate
                        }).OrderByDescending(x => x.ModifiedDate).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            /*ViewBag.Categories = db.Category.Where(x => x.IsActive).OrderBy(x => x.Order).ToList();*/

            return PartialView();
        }
        public ActionResult Edit(int id)
        {
            var data = db.Product.Find(id);
            /*ViewBag.Categories = db.Category.Where(x => x.IsActive).OrderBy(x => x.Order).ToList();*/

            ViewBag.images = db.ProductImage.Where(x => x.ProductId == id).ToList();



            return PartialView(data);
        }
        public ActionResult ListMaterial()
        {

            return PartialView();
        }

        [HttpPost]
        public JsonResult AddOrUpdate(Product eve, List<ProductImage> images)
        {
            //if (!ModelState.IsValid) return Json(false, JsonRequestBehavior.AllowGet); 
            if (eve.Id == 0)
            {
                eve.CreatedDate = DateTime.Now;
                eve.ModifiedDate = DateTime.Now;
                eve.Views = eve.Likes = 0;

                db.Product.Add(eve);
                db.Entry(eve).State = EntityState.Added;
                db.SaveChanges();
                var result = db.Product.OrderByDescending(x => x.Id).FirstOrDefault();

                if (images != null)
                {
                    images.Select(x => { x.ProductId = result.Id; return x; }).ToList();
                    db.ProductImage.AddRange(images);
                }
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }


            eve.ModifiedDate = DateTime.Now;
            db.Entry(eve).State = EntityState.Modified;

            if (images != null)
            {
                images.Select(x => { x.ProductId = eve.Id; return x; }).ToList();
                db.ProductImage.RemoveRange(db.ProductImage.Where(x => x.ProductId == eve.Id));

                db.ProductImage.AddRange(images);
            }

            db.SaveChanges();



            return Json(true, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteByID(int id)
        {
            try
            {
                List<ProductImage> events_img = db.ProductImage.Where(x => x.ProductId == id).ToList();
                db.ProductImage.RemoveRange(events_img);

                Product item = db.Product.Find(id);

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