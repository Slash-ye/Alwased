using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FullyProject.Models;

namespace FullyProject.Controllers
{
    [Authorize]
    public class PropertyTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyTypes
        public ActionResult Index()
        {
            return View(db.PropertyType.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeName")] PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                db.PropertyType.Add(propertyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }




        // POST: PropertyTypes/Delete/5
    
       
        public ActionResult Delete(int id)
        {
            PropertyType propertyType = db.PropertyType.Find(id);
            db.PropertyType.Remove(propertyType);
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
