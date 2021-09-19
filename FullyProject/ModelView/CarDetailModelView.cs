using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullyProject.ModelView
{
    public class CarDetailModelView
    {
        public string offerTitle { get; set; }
        public string code { get; set; }
        public string carModel { get; set; }//2008
        public string carType { get; set; }
        public decimal? price { get; set; }
        public string description { get; set; }
        public string phoneNumber { get; set; }
        public bool publish { get; set; }
        public string currencyName { get; set; }
        public string mainImage { get; set; }


        //Lists
        public List<Photo> photos { get; set; }
        public List<Service> Services { get; set; }
    }
}