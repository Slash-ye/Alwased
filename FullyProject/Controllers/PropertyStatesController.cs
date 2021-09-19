using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullyProject.Controllers
{
    [Authorize]
    public class PropertyStatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyTypes
        public ActionResult Index()
        {
            return View(db.PropertyState.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StateName")] PropertyState propertyState)
        {
            if (ModelState.IsValid)
            {
                db.PropertyState.Add(propertyState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }




        // POST: PropertyTypes/Delete/5


        public ActionResult Delete(int id)
        {
            PropertyState propertyState = db.PropertyState.Find(id);
            db.PropertyState.Remove(propertyState);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
