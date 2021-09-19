using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FullyProject.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="الخانه مطلوبه")]
        public string TypeName { get; set; }


        public ICollection<PropertyOffer> Property { get; set; }
    }
}