using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FullyProject.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace FullyProject.Controllers
{
    [Authorize]
    public class OnlineProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OnlineProjects
        public ActionResult Index()
        {
            return View(db.OnlineProject.ToList());
        }

        // GET: OnlineProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineProject onlineProject = db.OnlineProject.Find(id);
            if (onlineProject == null)
            {
                return HttpNotFound();
            }
            return View(onlineProject);
        }

        // GET: OnlineProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlineProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,dateOfStarted,description")] OnlineProject onlineProject, HttpPostedFileBase photo, IEnumerable<HttpPostedFileBase> photos)
        {
            if (ModelState.IsValid)
            {
                //Validate Images

                if (photo != null && photos != null)
                {
                    if (!IsValidType(photo.ContentType))
                    {
                        ModelState.AddModelError(string.Empty, " (png - gif - jpg)الرجاء ادخال صور تحت امتداد المسموح  ");
                        //ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
                        return View(onlineProject);
                    }

                    else
                    {
                        

                        //End

                        if (photo.ContentLength > 0)
                        {
                            var fileName = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(photo.FileName);

                            var path = Path.Combine(Server.MapPath("~/Images/OnlineProjectImages"), fileName);
                            photo.SaveAs(path);
                            Photo po = new Photo();
                            string img =  fileName;
                            // po.photoOwnerId = po.onLineProject;
                            // po.isMain = true;
                            //po.elementid = id;
                            //storing img exte
                            //db.Photo.Add(po);

                            onlineProject.mainImage = img;

                        }
                        onlineProject.ManagerId = User.Identity.GetUserId();
                        //Start add to database
                        db.OnlineProject.Add(onlineProject);
                        db.SaveChanges();
                        int id = onlineProject.Id;
                        /*
                        carOffer.addDate = DateTime.Now;
                        carOffer.ManagerId = User.Identity.GetUserId();
                        db.CarOffer.Add(carOffer);
                        db.SaveChanges();
                        //ading code for the offer
                        int id = carOffer.Id;
                        db.Database.ExecuteSqlCommand("UPDATE CarOffers SET code={0} where Id={1}", "Car-" + id, id);
                        */


                        foreach (var file in photos)
                        {
                            //if (file==null) { break; }
                            var fileName = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/OnlineProjectImages"), fileName);
                            file.SaveAs(path);
                            //storing img exte
                            Photo po = new Photo();
                            po.path =  fileName;
                            po.photoOwnerId = Photo.carOffer;
                            //po.isMain = false;
                            po.elementid = id;
                            //storing img exte
                            db.Photo.Add(po);

                        }
                        }
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                else
                {
                    ModelState.AddModelError(string.Empty, "الرجاء ادخال الصور");
                    //ViewBag.currencyTypeId = new SelectList(db.CurrencyType, "Id", "currencyName");
                    return View(onlineProject);
                }
            }
                

            //adding images


            return View(onlineProject);

            }
           
         
        private bool IsValidType(string content)
        {
            return content.Equals("image/png") || content.Equals("image/gif") || content.Equals("image/jpg") || content.Equals("image/jpeg");
        }
        // GET: OnlineProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineProject onlineProject = db.OnlineProject.Find(id);
            if (onlineProject == null)
            {
                return HttpNotFound();
            }
            return View(onlineProject);
        }

        // POST: OnlineProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,dateOfStarted,description")] OnlineProject onlineProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onlineProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(onlineProject);
        }

        // GET: OnlineProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OnlineProject onlineProject = db.OnlineProject.Find(id);
            if (onlineProject == null)
            {
                return HttpNotFound();
            }
            return View(onlineProject);
        }

        // POST: OnlineProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OnlineProject onlineProject = db.OnlineProject.Find(id);
            db.OnlineProject.Remove(onlineProject);
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
