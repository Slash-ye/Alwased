using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class DistanceUnit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الخانه مطلوبه")]
        public string unitName { get; set; }

        public ICollection<PropertyOffer> Property { get; set; }
    }
}