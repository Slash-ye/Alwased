using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullyProject.Controllers
{
    [Authorize]
    public class CurrencyTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyTypes
        public ActionResult Index()
        {
            return View(db.CurrencyType.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,currencyName")] CurrencyType currencyType)
        {
            if (ModelState.IsValid)
            {
                db.CurrencyType.Add(currencyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }




        // POST: PropertyTypes/Delete/5


        public ActionResult Delete(int id)
        {
            CurrencyType currencyType = db.CurrencyType.Find(id);
            db.CurrencyType.Remove(currencyType);
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
