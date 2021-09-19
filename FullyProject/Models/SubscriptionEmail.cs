using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class SubscriptionEmail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [EmailAddress(ErrorMessage = "الرجاء ادخال ايميل")]
        public string email { get; set; }
        public bool active { get; set; }
    }
}