using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class CurrencyType
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانه مطلوبه")]
        public string currencyName { get; set; }

        public ICollection<PropertyOffer> Property { get; set; }
        public ICollection<CarOffer> CarOffer { get; set; }


    }
}