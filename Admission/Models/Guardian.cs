using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Admission.Models
{
    public class Guardian
    {
        [Key]
        public string GuardianID { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Full Names")]
        public string Full_Names { get; set; }

        [Required]
        [Display(Name = "CellNo")]
        public double cell_No { get; set; }

        [Required]
        [Display(Name = "Identity Number")]
        public string identity_No { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string postal_address { get; set; }

        [Display(Name = "Upload Documents")]
        public Byte[] Documents { get; set; }
    }
}