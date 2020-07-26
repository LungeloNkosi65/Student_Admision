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
        public string GEmail { get; set; }
        [Display(Name = "Surname")]
        public string GSurname { get; set; }

        [Display(Name = "Full Names")]
        public string GFull_Names { get; set; }

        [Display(Name = "CellNo")]
        public double Gcell_No { get; set; }

        [Display(Name = "Identity Number")]
        public string Gidentity_No { get; set; }


        [Display(Name = "Address")]
        public string Gpostal_address { get; set; }

        [Display(Name = "Upload Documents")]
        public Byte[] GDocuments { get; set; }

        public string StudentEmail { get; set; }
    }
}