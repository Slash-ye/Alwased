using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FullyProject.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace FullyProject.Controllers
{
    [Authorize]
    public class CarOffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarOffers
        public ActionResult Index(string searchString)
        {
            var c = from s in db.CarOffer.OrderByDescending(u => u.addDate)
                    select s            ;
            if (!String.IsNullOrEmpty(searchString))
            {
                c = c.Where(s => s.code.ToUpper().Contains(searchString.ToUpper())).OrderByDescending(u => u.addDate);
            }
            ViewBag.carCount = db.CarOffer.Count();
            return View(c.ToList());
        }

        // GET: CarOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOffer carOffer = db.CarOffer.Find(id);
            if (carOffer == null)
            {
                return HttpNotFound();
            }
            return View(carOffer);
        }

        // GET: CarOffers/Create
        public ActionResult Create()
        {
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
            return View();
        }

        
       
        // POST: CarOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,offerTitle,carModel,carType,price,description,phoneNumber,finishDate,publish,currencyTypeId")] CarOffer carOffer, HttpPostedFileBase photo, IEnumerable<HttpPostedFileBase> photos)
        {
            if (ModelState.IsValid)
            {
                //Validate Images
                
                if (photo != null && photos != null)
                {
                    if (!IsValidType(photo.ContentType))
                    {
                        ModelState.AddModelError(string.Empty, " (png - gif - jpg)الرجاء ادخال صور تحت امتداد المسموح  ");
                        ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
                        return View(carOffer);
                    }

                    else
                    {

                        //file Name
                        //dest
                        //retrun img
                         
                        if (photo.ContentLength > 0)
                        {
                            var fileName = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(photo.FileName);

                            var path = Path.Combine(Server.MapPath("~/Images/CarOfferImages"), fileName);
                            photo.SaveAs(path);
                            Photo po = new Photo();
                            string img = fileName;
                            //po.photoOwnerId = po.carOffer;
                            //po.isMain = true;
                            //po.elementid = id;
                            //storing img exte
                            //db.Photo.Add(po);
                            carOffer.mainImage = img;
                        }
                        //Start add to database

                        carOffer.addDate = DateTime.Now;
                        carOffer.ManagerId = User.Identity.GetUserId();
                        
                        db.CarOffer.Add(carOffer);
                        db.SaveChanges();
                        //ading code for the offer
                        int id = carOffer.Id;
                        db.Database.ExecuteSqlCommand("UPDATE CarOffers SET code={0} where Id={1}", "Car-" + id, id);
                        //End


                        foreach (var file in photos)
                        {
                            var fileName = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/CarOfferImages"), fileName);
                            file.SaveAs(path);
                            //storing img exte
                            Photo po = new Photo();
                            po.path = fileName;
                            po.photoOwnerId = Photo.carOffer;
                           // po.isMain = false;
                            po.elementid = id;
                            //storing img exte
                            db.Photo.Add(po);

                        }

                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "الرجاء ادخال الصور");
                    ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
                    return View(carOffer);
                }
           
                //adding images


                
    
            }
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
            return View(carOffer);
        }
        private bool IsValidType(string content)
        {
            return content.Equals("image/png") || content.Equals("image/gif") || content.Equals("image/jpg") || content.Equals("image/jpeg");
        }
        // GET: CarOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOffer carOffer = db.CarOffer.Find(id);
            if (carOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");

            return View(carOffer);
        }

        // POST: CarOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,offerTitle,carModel,carType,price,description,phoneNumber,publish,currencyTypeId")] CarOffer carOffer)
        {
            if (ModelState.IsValid)
            {
                carOffer.addDate = DateTime.Now;
                db.Entry(carOffer).State = EntityState.Modified;
                db.SaveChanges();
                //ading code for the offer
                int id = carOffer.Id;
                db.Database.ExecuteSqlCommand("UPDATE CarOffers SET code={0} where Id={1}", "Car-" + id, id);


                return RedirectToAction("Index");
            }
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
            return View(carOffer);
        }

        // GET: CarOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOffer carOffer = db.CarOffer.Find(id);
            if (carOffer == null)
            {
                return HttpNotFound();
            }
            return View(carOffer);
        }

        // POST: CarOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarOffer carOffer = db.CarOffer.Find(id);
            db.CarOffer.Remove(carOffer);
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
