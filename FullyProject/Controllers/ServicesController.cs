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

namespace FullyProject.Controllers
{
    [Authorize]
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Services
        public ActionResult Index()
        {
            return View(db.Service.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,description")] Service service, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            if (ModelState.IsValid)
            {
               
                if (image1 != null && image2 != null)
                {
                    if (!IsValidType(image1.ContentType)&& !IsValidType(image2.ContentType))
                    {
                        ModelState.AddModelError(string.Empty, " (png - gif - jpg)الرجاء ادخال صور تحت امتداد المسموح  ");
                       return View(service);
                    }

                    else
                    {
                        if (image1.ContentLength > 0 && image2.ContentLength > 0)
                        {
                            var fileName1 = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(image1.FileName);
                            var fileName2 = System.DateTime.Now.ToString("_ddMMyyhhmmss") + Path.GetFileName(image2.FileName);

                            var path1 = Path.Combine(Server.MapPath("~/Images/ServiceImages"), fileName1);
                            var path2 = Path.Combine(Server.MapPath("~/Images/ServiceImages"), fileName2);

                            image1.SaveAs(path1);
                            image2.SaveAs(path2);


                            service.image1 = fileName1;
                            service.image2 = fileName2;
                            
                        }

                        //Start add to database
                        db.Service.Add(service);
                        db.SaveChanges();
                        //End

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "الرجاء ادخال الصور");
                    return View(service);
                }



            }

            return View(service);
        }
        private bool IsValidType(string content)
        {
            return content.Equals("image/png") || content.Equals("image/gif") || content.Equals("image/jpg") || content.Equals("image/jpeg");
        }
        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,description,image1,image2")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Service.Find(id);
            db.Service.Remove(service);
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
