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
    public class PropertyOffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyOffers
        public ActionResult Index(int? id , string searchString)
        {
            var propertyOffer = from s in db.PropertyOffer.OrderByDescending(u => u.addDate)
                                select s;

            if (id != null)
            { propertyOffer = propertyOffer.Where(i => i.PropertyTypeId == id).OrderByDescending(u => u.addDate); }
            //PropertyOffer propertyOffer = db.PropertyOffer.Select(u => new { code = u.code, Id = u.Id, address
            
            if (!String.IsNullOrEmpty(searchString))
            {
                propertyOffer = propertyOffer.Where(s => s.code.ToUpper().Contains(searchString.ToUpper())).OrderByDescending(u => u.addDate);
            }
            ViewBag.Pt = db.PropertyType.ToList();
            ViewBag.propCount = db.PropertyOffer.Count();
            return View(propertyOffer.ToList());
        }

       
        // GET: PropertyOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOffer propertyOffer = db.PropertyOffer.Find(id);
            if (propertyOffer == null)
            {
                return HttpNotFound();
            }
            return View(propertyOffer);
        }

        // GET: PropertyOffers/Create
        public ActionResult Create()
        {
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
            ViewBag.distanceUnitId = new SelectList(db.DistanceUnit, "Id", "unitName");
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TypeName");
            ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName");
            return View();
        }

        // POST: PropertyOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,offerTitle,country,city,address,price,distance,publish,phoneNumber,description,bedroomNumber,bathroomNumber,PropertyTypeId,currencyTypeId,distanceUnitId,PropertyStateId")] PropertyOffer propertyOffer,HttpPostedFileBase photo,IEnumerable<HttpPostedFileBase> photos)
        {
            if (ModelState.IsValid)
            {
                //propertyOffer.code = "Pro-" + propertyOffer.Id;
                //Code  in other with imgs for intering Pro-Id
                /*
                propertyOffer.ManagerId = User.Identity.GetUserId();
                propertyOffer.addDate = DateTime.Now;
               
                db.PropertyOffer.Add(propertyOffer);
                db.SaveChanges();
                int id =propertyOffer.Id;
                */

                //Validate Images

                if (photo != null && photos != null)
                {
                    if (!IsValidType(photo.ContentType))
                    {
                        ModelState.AddModelError(string.Empty, " (png - gif - jpg)الرجاء ادخال صور تحت امتداد المسموح  ");
                        ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName", propertyOffer.currencyTypeId);
                        ViewBag.distanceUnitId = new SelectList(db.DistanceUnit, "Id", "unitName", propertyOffer.distanceUnitId);
                        ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TypeName", propertyOffer.PropertyTypeId);
                        ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName", propertyOffer.PropertyStateId);
                        return View(propertyOffer);
                    }

                    else
                    {
                        

                        if (photo.ContentLength > 0)
                        {
                            var fileName = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(photo.FileName);

                            var path = Path.Combine(Server.MapPath("~/Images/PropertyOfferImages"), fileName);
                            photo.SaveAs(path);
                            Photo po = new Photo();
                           string img = "~/Images/PropertyOfferImages/" + fileName;
                            // po.photoOwnerId = po.propertyOffer;
                            //po.isMain = true;
                            // po.elementid = id;
                            //storing img exte
                            propertyOffer.mainImage = img;

                        }
                        //Start add to database

                        propertyOffer.addDate = DateTime.Now;
                        propertyOffer.ManagerId = User.Identity.GetUserId();
                        db.PropertyOffer.Add(propertyOffer);
                        db.SaveChanges();
                        //ading code for the offer
                        int id = propertyOffer.Id;
                        db.Database.ExecuteSqlCommand("UPDATE propertyOffers SET code={0} where Id={1}", "Pro-" + id, id);


                        //End

                        foreach (var file in photos)
                        {
                            var fileName = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/PropertyOfferImages"), fileName);
                            file.SaveAs(path);
                            //storing img exte
                            Photo po = new Photo();
                            po.path =  fileName;
                            po.photoOwnerId = Photo.propertyOffer;
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
                    ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName", propertyOffer.currencyTypeId);
                    ViewBag.distanceUnitId = new SelectList(db.DistanceUnit, "Id", "unitName", propertyOffer.distanceUnitId);
                    ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TypeName", propertyOffer.PropertyTypeId);
                    ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName", propertyOffer.PropertyStateId);
                    return View(propertyOffer);
                }

            }

            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName", propertyOffer.currencyTypeId);
            ViewBag.distanceUnitId = new SelectList(db.DistanceUnit, "Id", "unitName", propertyOffer.distanceUnitId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TypeName", propertyOffer.PropertyTypeId);
            ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName", propertyOffer.PropertyStateId);
            return View(propertyOffer);
        }
        private bool IsValidType(string content)
        {
            return content.Equals("image/png") || content.Equals("image/gif") || content.Equals("image/jpg") || content.Equals("image/jpeg");
        }
        // GET: PropertyOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOffer propertyOffer = db.PropertyOffer.Find(id);
            if (propertyOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName", propertyOffer.currencyTypeId);
            ViewBag.distanceUnitId = new SelectList(db.DistanceUnit, "Id", "unitName", propertyOffer.distanceUnitId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TypeName", propertyOffer.PropertyTypeId);
            ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName", propertyOffer.PropertyStateId);
            return View(propertyOffer);
        }

        // POST: PropertyOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,offerTitle,country,city,address,price,distance,publish,phoneNumber,description,bedroomNumber,bathroomNumber,PropertyTypeId,currencyTypeId,distanceUnitId,PropertyStateId")] PropertyOffer propertyOffer)
        {
            if (ModelState.IsValid)
            {
                /*
                PropertyOffer po = new PropertyOffer();
                po.Id = propertyOffer.Id;
                po.offerTitle = propertyOffer.offerTitle;
                po.country = propertyOffer.country;
                po.city = propertyOffer.city;
                po.address = propertyOffer.address;
                po.price = propertyOffer.price;
                po.distance = propertyOffer.distance;
                po.publish = propertyOffer.publish;
                po.phoneNumber = propertyOffer.phoneNumber;
                po.description = propertyOffer.description;
                
               po.bedroomNumber= propertyOffer.bedroomNumber;
                po.bathroomNumber = propertyOffer.bathroomNumber;
                po.PropertyTypeId = propertyOffer.PropertyTypeId;
                po.currencyTypeId = propertyOffer.currencyTypeId;
                po.distanceUnitId = propertyOffer.distanceUnitId;
                po.PropertyStateId = propertyOffer.PropertyStateId;

               //db.SaveChanges();
                */
                propertyOffer.addDate = DateTime.Now;
                propertyOffer.ManagerId = User.Identity.GetUserId();


                db.Entry(propertyOffer).State = EntityState.Modified;
                db.SaveChanges();
                //ading code for the offer
                int id = propertyOffer.Id;
                db.Database.ExecuteSqlCommand("UPDATE propertyOffers SET code={0} where Id={1}", "Pro-" + id, id);


                return RedirectToAction("Index");
            }
            ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName", propertyOffer.currencyTypeId);
            ViewBag.distanceUnitId = new SelectList(db.DistanceUnit, "Id", "unitName", propertyOffer.distanceUnitId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TpyeName", propertyOffer.PropertyTypeId);
            ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName", propertyOffer.PropertyStateId);
            return View(propertyOffer);
        }

        // GET: PropertyOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOffer propertyOffer = db.PropertyOffer.Find(id);
            if (propertyOffer == null)
            {
                return HttpNotFound();
            }
            return View(propertyOffer);
        }

        // POST: PropertyOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyOffer propertyOffer = db.PropertyOffer.Find(id);
            db.PropertyOffer.Remove(propertyOffer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*
        public ActionResult GetPropertyType()
        {
            
            var pt = db.PropertyType.OrderBy(u=>u.TypeName);
            return View(pt.ToList());
        }
        */
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
