using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class ContactInfoMessage
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الاسم بالكامل")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الرساله")]
        public string message { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الايميل الخاص بك")]
        [EmailAddress(ErrorMessage = "الرجاء ادخال ايميل")]
        public string email { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "رقم الهاتف")]
        [Phone(ErrorMessage = "رقم الهاتف غير متاح")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "الرجاء ادخال رقم هاتف")]
        public string phoneNumber { get; set; }
        
        public string codeOfInterest { get; set; }
        public bool isRead { get; set; }
        public DateTime? addDate { get; set; }
        public bool active { get; set; }
    }
   
}