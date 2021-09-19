using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullyProject.ModelView
{
    public class PropertyDetailModelView
    {
      
        public string offerTitle { get; set; }
        public string code { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public decimal? price { get; set; }
        public int? distance { get; set; }
        public string phoneNumber { get; set; }
        public string description { get; set; }
        public int? bedroomNumber { get; set; }
        public string mainImage { get; set; }
        public int? bathroomNumber { get; set; }
        public string currencyName { get; set; }

        //Lists
        public List<Photo> photos { get; set; }
        public List<Service> Services { get; set; }
        
    }

}