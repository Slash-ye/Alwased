using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class PropertyOffer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "مسمئ العقار")]
        public string offerTitle { get; set; }
        public string code { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الدوله")]
        public string country { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "المدينه")]
        public string city { get; set; }
        [Display(Name = "العنوان")]
        public string address { get; set; }
        [Display(Name = "السعر")]
        [DataType(DataType.Currency, ErrorMessage = "أرجاء ادخال السعر")]
        public decimal? price { get; set; }
        [Display(Name = "المساحه")]

        public int? distance { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime? addDate { get; set; }
       
        [Display(Name = "النشر في الموقع")]

        public bool publish { get; set; }
       // [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        [Display(Name = "رقم الهاتف")]
        [Phone(ErrorMessage = "رقم الهاتف غير متاح")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "الرجاء ادخال رقم هاتف")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الوصف")]

        public string description { get; set; }
       
        [Display(Name = "عدد الغرف")]

        public int? bedroomNumber { get; set; }
        [Display(Name = "عدد الحمامات")]

        public int? bathroomNumber { get; set; }
    
        public int? PropertyTypeId { get; set; }
      
        public int? currencyTypeId { get; set; }
       
        public int? distanceUnitId { get; set; }
       
        public int? PropertyStateId { get; set; }
        //public int propertyDetailId { get; set; }
        public string ManagerId { get; set; }

        public PropertyState PropertyState { get; set; }
        public  CurrencyType CurrencyType { get; set; }
        public DistanceUnit DistanceUnit { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        //public PropertyDetial PropertyDetial { get; set; }
        public ApplicationUser Manager { get; set; }
        
        public string mainImage { get; set; }



    }
}