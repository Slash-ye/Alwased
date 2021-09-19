using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class CarOffer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "عنوان العرض")]
        public string offerTitle { get; set; }
        public string code { get; set; }
        
        [Display(Name = "موديل السياره")]
        public string carModel { get; set; }//2008
       
        [Display(Name = "نوع السياره")]
        public string carType { get; set; }
       
        [Display(Name = "السعر")]
        [DataType(DataType.Currency, ErrorMessage = "أرجاء ادخال السعر")]
        public decimal? price { get; set; }
        // public bool isArgumented { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الوصف")]
        public string description { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "رقم الهاتف")]
        [Phone(ErrorMessage = "رقم الهاتف غير متاح")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "الرجاء ادخال رقم هاتف")]
        public string phoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime? addDate { get; set; }
       
       
        
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "النشر في الموقع")]
        public bool publish { get; set; }
        [Display(Name = "نوع العمله")]
        public int currencyId { get; set; }

        public string ManagerId { get; set; }

        public ApplicationUser Manager { get; set; }
        public CurrencyType CurrencyType { get; set; }
       
        public string mainImage { get; set; }
    }
   
}