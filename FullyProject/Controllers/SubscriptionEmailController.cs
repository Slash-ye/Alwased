using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FullyProject.Controllers
{
    [Authorize]
    public class SubscriptionEmailController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SubscriptionEmail
        public ActionResult Index()
        {
            var Submail = db.SubscriptionEmail.ToList();
            return View(Submail);
        }

        // Post: SubscriptionEmail/UnActive/5
        public ActionResult UnActive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionEmail Sub = db.SubscriptionEmail.Find(id);

            if (Sub == null)
            {
                return HttpNotFound();
            }
            

            if (Sub.active)
            {
                db.Database.ExecuteSqlCommand("UPDATE SubscriptionEmails SET active={0} where Id={1}", false,id);
            }
            if (Sub.active==false)
            {
                db.Database.ExecuteSqlCommand("UPDATE SubscriptionEmails SET active={0} where Id={1}", true,id);
            }
            /*
            db.Entry(Sub).State = EntityState.Modified;
            db.SaveChanges();
            */
            return RedirectToAction("Index");


        }

        // GET: SubscriptionEmail/Create
        /*
        [AllowAnonymous]

        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionEmail/Create
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        */

        // Get: SubscriptionEmail/Delete/5

        public ActionResult Delete(int id)
        {
            SubscriptionEmail sub = db.SubscriptionEmail.Find(id);
            db.SubscriptionEmail.Remove(sub);
            db.SaveChanges();

            return RedirectToAction("Index");
           

              
           
        }
    }
}
