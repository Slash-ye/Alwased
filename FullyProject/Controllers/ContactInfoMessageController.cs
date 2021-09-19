using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullyProject.Controllers
{
    [Authorize]
    public class ContactInfoMessageController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ContactInfoMessage
        public ActionResult Index(bool? isRead)
        {
            
            var m=db.ContactInfoMessage.Where(u=>u.isRead==false).OrderByDescending(u=>u.addDate);
            if (isRead!=null)
            { m = db.ContactInfoMessage.Where(u => u.isRead == isRead).OrderByDescending(u => u.addDate); }


            ViewBag.massage = db.ContactInfoMessage.Where(u=>u.isRead==false).Count();
            return View(m.ToList());
        }

        public JsonResult ChangeToRead(int id)
        {
            //have to change to ajax or or changing the model
            bool r = false;
            db.Database.ExecuteSqlCommand("UPDATE ContactInfoMessages SET isRead={0} where Id={1}", true, id);
            r = true;

            return Json(r, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            ContactInfoMessage cim = db.ContactInfoMessage.Find(id);
            db.ContactInfoMessage.Remove(cim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [AllowAnonymous]

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Create(ContactInfoMessage c)
        {
            c.addDate = DateTime.Now;
            c.active = true;
            c.isRead = false;

            db.ContactInfoMessage.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}