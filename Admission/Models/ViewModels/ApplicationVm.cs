using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Admission.Models
{
    public class ApplicationVm
    {
        public int ApplicationVmId { get; set; }
        public string StudentId { get; set; }
        public string AdmisionId { get; set; }
        public string GuardianID { get; set; }
        [DisplayName("StudentEmail")]
        public string StudentEmail { get; set; }
        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        [DisplayName("Student Surname")]
        public string Surname { get; set; }
        [DisplayName("Gaurdian Name")]
        public string ParentName { get; set; }
        [DisplayName("Gaurdian Contact")]
        public double Parent_Cell { get; set; }
        [DisplayName("Id Number")]
        public string Identity_Number { get; set; }
        public string Address { get; set; }
        [DisplayName("ApplicationStatus")]
        public string Application_Status { get; set; }


        ApplicationDbContext db = new ApplicationDbContext();


    }
}