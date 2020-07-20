using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Admission.Models
{
    public class Admission_Information
    {
        [Key]
        public string UserId { get; set; }
        public string Email { get; set; }
        [Display(Name = "Date Application"),DataType(DataType.Date)]
        public DateTime Dtae  { get; set; }

        [Required]
        [Display(Name = "Previous School")]
        public string previous_school { get; set; }

        [Required]
        [Display(Name = "Class admitted")]
        public string class_admitted { get; set; }

        [Required]
        [Display(Name = "Previous School Address")]
        public string address { get; set; }

        [Display(Name = "Admision Status")]
        public string Upload { get; set; }


   }
}