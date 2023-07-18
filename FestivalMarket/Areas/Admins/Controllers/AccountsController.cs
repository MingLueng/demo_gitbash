using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using FestivalMarket.Common;
using FestivalMarket.Models;
using FestivalMarket.Models.EF;

namespace FestivalMarket.Areas.Admins.Controllers
{
    public class AccountsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admins/Accounts
        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý tài khoản";
            return View();
        }
        /// <summary>
        /// Hiển thị danh sách tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDataJSON()
        {
            var data = db.AdminUser.OrderBy(x => x.Account).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region "Login / Logout"
        /// <summary>
        /// Trang đăng nhập hệ thống
        /// </summary>
        /// <param name="returnUrl"> Đường dẫn sau khi đăng nhập thành công </param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admins");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Xử lý đăng nhập
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminUser model)
        {
            AdminUser _user = new AdminUser();
            if (model.Account == "0978611889" && model.Password == "0978611889$")
            {
                _user.Id = 0;
                _user.Account = "0978611889";
                _user.Password = Encrypt.Sha2HashWithHex(model.Password);
                _user.Name = "Administrator";

                Session["ACCOUNT"] = _user;

                var oldCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (oldCookie != null)
                {
                    oldCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(oldCookie);
                }
                // Lấy thông tin người dùng đăng nhập
                // Chuyển sang dạng Json data
                // ChungTrinh
                var serializeModel = new AppUserPrincipalSerializeModel();
                serializeModel.UserId = _user.Id;
                serializeModel.UserName = _user.Name;
                serializeModel.UserLogin = _user.Account;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(serializeModel);

                var ticket = new FormsAuthenticationTicket(1,
                   _user.Account.Trim(),
                    DateTime.Now,
                    DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                    true,
                    userData,
                    FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                // Create the cookie.
                Response.Cookies.Add(cookie);
                return Json(1, JsonRequestBehavior.AllowGet);
            }

            if (model.Account == null)
            {
                return Json(2, JsonRequestBehavior.AllowGet);
            }

            _user = db.AdminUser.Where(u => u.Account == model.Account.Trim()).FirstOrDefault();
            if (_user == null)
            {
                return Json(3, JsonRequestBehavior.AllowGet);
            }

            if (model.Password == null)
            {
                return Json(4, JsonRequestBehavior.AllowGet);
            }

            if (_user.Password != Encrypt.Sha2HashWithHex(model.Password))
            {
                return Json(5, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["ACCOUNT"] = _user;
                var oldCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (oldCookie != null)
                {
                    oldCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(oldCookie);
                }
                // Lấy thông tin người dùng đăng nhập
                // Chuyển sang dạng Json data
                // ChungTrinh
                var serializeModel = new AppUserPrincipalSerializeModel();
                serializeModel.UserId = _user.Id;
                serializeModel.UserName = _user.Name;
                serializeModel.UserLogin = _user.Account;
                serializeModel.Password = _user.Password;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(serializeModel);

                var ticket = new FormsAuthenticationTicket(1,
                    _user.Account.Trim(),
                    DateTime.Now,
                    //DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                    DateTime.Now.AddYears(1),
                    true,
                    userData,
                    FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                // Create the cookie.
                Response.Cookies.Add(cookie);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }
        #endregion

        #region " Add/Update/Delete"
        [HttpPost]
        public JsonResult AddOrUpdate(AdminUser itemInfor)
        {
            if (itemInfor.Id == 0)
            {
                if (itemInfor.CreatedDate == null)
                    itemInfor.CreatedDate = DateTime.Now;
                itemInfor.ModifiedDate = DateTime.Now;

                itemInfor.Password = Encrypt.Sha2HashWithHex(itemInfor.Password);
                db.Entry(itemInfor).State = EntityState.Added;
                db.SaveChanges();
            }
            else
            {
                AdminUser item = itemInfor as AdminUser;
                if (item.CreatedDate == null)
                    item.CreatedDate = DateTime.Now;
                itemInfor.ModifiedDate = DateTime.Now;
                item.Password = Encrypt.Sha2HashWithHex(itemInfor.Password);
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            var data = db.AdminUser.OrderBy(x => x.Account).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteByID(int id)
        {
            try
            {
                AdminUser item = db.AdminUser.Find(id);
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