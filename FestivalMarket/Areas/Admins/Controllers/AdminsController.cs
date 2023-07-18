using FestivalMarket.Common.Attributes;
using FestivalMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FestivalMarket.Areas.Admins.Controllers
{
    public class AdminsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admins/Admins
        [CustomAuthorize]
        public ActionResult Index()
        {
            ViewBag.TaiKhoan = db.AdminUser.Count();
            ViewBag.SanPham = db.Product.Count();
            ViewBag.SuKien = db.Events.Count();
            ViewBag.Slide = db.Slides.Count();
            ViewBag.KhuyenMai = db.Sales.Count();
            ViewBag.TinTuc = db.News.Count();
            ViewBag.DanhMuc = db.Category.ToList();
            return View();
        }
    }
}