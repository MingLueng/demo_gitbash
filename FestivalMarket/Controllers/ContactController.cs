using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using FestivalMarket.Models;
using FestivalMarket.Models.EF;
namespace FestivalMarket.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddContact()
        {
            return PartialView();

        }
        public ActionResult AddContactSuccess()
        {
            return PartialView();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContact(ContactViewModel cvm)
        {

            var code = new { success = false, msg = "", code = -1 };
            if (ModelState.IsValid) 
            {
                Contact contact = new Contact();
                contact.Title = cvm.Title;
                contact.Name = cvm.Name;
                contact.Message = cvm.Message;
                contact.Phone = cvm.Phone;
                contact.Email = cvm.Email;
                contact.CreatedDate = DateTime.Now;
                contact.ModifiedDate = DateTime.Now;
                contact.CreatedBy = cvm.Phone;
                db.Contact.Add(contact);
                db.SaveChanges();
                code = new { success = true, msg = "", code = 1 };
                return RedirectToAction("AddContactSuccess");


            }
            return Json(code);
        }
        
    }
}