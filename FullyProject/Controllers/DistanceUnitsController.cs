using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullyProject.Controllers
{
    [Authorize]
    public class DistanceUnitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyTypes
        public ActionResult Index()
        {
            return View(db.DistanceUnit.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,unitName")] DistanceUnit distanceUnit)
        {
            if (ModelState.IsValid)
            {
                db.DistanceUnit.Add(distanceUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }




        // POST: PropertyTypes/Delete/5


        public ActionResult Delete(int id)
        {
            DistanceUnit distanceUnit = db.DistanceUnit.Find(id);
            db.DistanceUnit.Remove(distanceUnit);
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
