using FullyProject.Models;
using FullyProject.ModelView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullyProject.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            IndexModelView i = new IndexModelView();
            
            List<PropertyOffer> prop = db.PropertyOffer.Where(x=>x.publish==true).Include(x=>x.CurrencyType).OrderByDescending(x => x.addDate).Take(6).ToList();
            List<CarOffer> car = db.CarOffer.Where(x => x.publish == true).Include(x => x.CurrencyType).OrderByDescending(p => p.addDate).Take(6).ToList();
            List<Service> ser = db.Service.ToList();
            
            i.PropertyOffers = prop;
            i.CarOffers = car;
            i.Services = ser;

            ViewBag.PropertyStateId = new SelectList(db.PropertyState, "Id", "StateName");
            ViewBag.PropertyTypeId = new SelectList(db.PropertyType, "Id", "TypeName");
            ViewBag.Country = new SelectList(db.PropertyOffer, "country", "country");
            ViewBag.City = new SelectList(db.PropertyOffer, "city", "city");


            

            return View(i);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult ContactThank()
        {

            return View();
        }
        public ActionResult show()
        {
            return View();
        }
        
        public ActionResult AllProperty()
        {
            AllPropertyModelView P = new AllPropertyModelView();
           List<PropertyOffer> p= db.PropertyOffer.Where(x => x.publish == true).Include(x => x.CurrencyType).OrderByDescending(x => x.addDate).ToList();
           List<Service> s = db.Service.ToList();

            P.PropertyOffers = p;
            P.Services = s;
            return View(P);
        }
        public ActionResult AllCar()
        {
            AllCarModelView C = new AllCarModelView();
            List<CarOffer> c = db.CarOffer.Where(x => x.publish == true).Include(x => x.CurrencyType).OrderByDescending(x => x.addDate).ToList();
            List<Service> s = db.Service.ToList();

            C.CarOffers = c;
            C.Services = s;
            return View(C);
        }

        public ActionResult ContactMessage(ContactInfoMessage c)
        {
            if (ModelState.IsValid)
            {
                c.addDate = DateTime.Now;
                c.active = true;
                c.isRead = false;

                db.ContactInfoMessage.Add(c);
                db.SaveChanges();

                return Json("تم أرسال الرساله بنجاح", JsonRequestBehavior.AllowGet);
            }
            return Json("خطاء لم يتم الارسال", JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult ContactUs()
        {
            return PartialView();
        }
        /*
        [HttpPost]
        public JsonResult ContactMessage(ContactInfoMessage c)
        {
            bool r = false;
            if(ModelState.IsValid)
            { 
            c.addDate = DateTime.Now;
            c.active = true;
            c.isRead = false;

            db.ContactInfoMessage.Add(c);
            db.SaveChanges();
                r = true;

                return Json(r, JsonRequestBehavior.AllowGet);
            }
            return Json(r, JsonRequestBehavior.AllowGet);
        }
        */
        [HttpPost]
         public ActionResult AddSubscriptionEmail(SubscriptionEmail s)
        {
            if (ModelState.IsValid)
            {
                s.active = true;
                db.SubscriptionEmail.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            //ModelState.AddModelError(email, "");
            return RedirectToAction("Index");
       }
        [HttpPost]
        public string SeachEngine()
        {
            return "";
        }

        public ActionResult PropertyDetails(int id)
        {
            var po = db.PropertyOffer.Where(p => p.Id == id).SingleOrDefault();
            if (po != null)
            {
                
                int ownerId = Photo.propertyOffer;
                var ph = db.Photo.Where(p => p.elementid == id && p.photoOwnerId == ownerId).ToList();
                var s = db.Service.ToList();

                PropertyDetailModelView pd = new PropertyDetailModelView();
                pd.address = po.address;
                pd.bathroomNumber = po.bathroomNumber;
                pd.bedroomNumber = po.bedroomNumber;
                pd.city = po.city;
                pd.code = po.code;
                pd.country = po.country;
                pd.description = po.description;
                pd.distance = po.distance;
                pd.mainImage = po.mainImage;
                pd.offerTitle = po.offerTitle;
                pd.phoneNumber = po.phoneNumber;
                pd.price = po.price;
               // pd.currencyName =po.CurrencyType.currencyName;

                pd.Services = s;
                pd.photos = ph;


                return View(pd);
            }
           
                return HttpNotFound();
           
           
        }
        public ActionResult CarDetails(int id)
        {
            var co = db.CarOffer.Where(p => p.Id == id).SingleOrDefault();
            if (co != null)
            {
                int ownerId = Photo.carOffer;
                var ph = db.Photo.Where(p => p.elementid == id && p.photoOwnerId == ownerId).ToList();
                var s = db.Service.ToList();

                CarDetailModelView cd = new CarDetailModelView();

                cd.carModel = co.carModel;
                cd.carType = co.carType;
                cd.code = co.code;
                cd.mainImage = co.mainImage;
               // cd.currencyName = co.currencyI;
                cd.description = co.description;
                cd.offerTitle = co.offerTitle;
                cd.phoneNumber = co.phoneNumber;
                cd.price = co.price;
                // pd.currencyName =po.CurrencyType.currencyName;


                cd.Services = s;
                cd.photos = ph;

                return View(cd);
            }
            return HttpNotFound();

        }

        public ActionResult Catagory()
        {
            return View();
        }
        //get
             public ActionResult NewProject()
        {
            return View();
        }
    }
}