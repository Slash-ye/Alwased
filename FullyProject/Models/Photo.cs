using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string path { get; set; }
        public int photoOwnerId { get; set; }
       // public bool isMain { get; set; }
        public int elementid { get; set; }//for element of the owner carId, propId , servicesid
       

        [NotMapped]
        public static int carOffer =1;
        [NotMapped]
        public static int propertyOffer =2 ;
        [NotMapped]
        public static int onLineProject = 3 ;
       
    }
}