using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "مسمئ الخدمه")]
        public string name { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الوصف")]
        public string description { get; set; }
       
        public string image1 { get; set; }
      
        public string image2 { get; set; }

    }
}