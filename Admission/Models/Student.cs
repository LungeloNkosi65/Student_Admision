using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admission.Models
{
    public class StudentInformation
    {
        [Key]
        public string UserId { get; set; }
        public string Email { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Full Names")]
        public string Full_Names { get; set; }

        [Required]
        [Display(Name = "Identity Number")]
        public string Identity_Number { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Required]
        [Display(Name = "Address")]
        public string postal_address { get; set; }

        //[Required]
        [Display(Name = "Upload Image")]
        public byte[] Image { get; set; }
        public string ImageType { get; set; }


    }
}