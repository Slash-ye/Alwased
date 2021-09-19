using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class OnlineProject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "مسمئ المشروع")]

        public string name { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "التاريخ البدء في المشروع")]
        [DataType(DataType.Date)]
        public DateTime dateOfStarted { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الوصف")]
        public string description { get; set; }
        public string ManagerId { get; set; }
        public ApplicationUser Manager { get; set; }

        
        public string mainImage { get; set; }

    }
}