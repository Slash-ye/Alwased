﻿using FullyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullyProject.ModelView
{
    public class IndexModelView
    {
        public List<PropertyOffer> PropertyOffers { get; set; }
        public List<CarOffer> CarOffers { get; set; }

        public List<Service> Services { get; set; }

    }
}