using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullyProject.ModelView
{
    public class AllPropertyModelView
    {
        public List<PropertyOffer> PropertyOffers { get; set; }
        public List<Service> Services { get; set; }
    }
   
}