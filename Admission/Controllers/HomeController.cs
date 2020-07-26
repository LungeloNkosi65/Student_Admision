using Admission.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admission.Controllers
{
    public class HomeController : Controller
    {
        public IEnumerable<ApplicationVm> Applications { get; set; }
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ApplicationStatus()
        {
            var userName = User.Identity.GetUserName();
            List<ApplicationVm> applicationVms = new List<ApplicationVm>();
            var dbRecords = (from st in db.Students
                             join g in db.Guardians
                             on st.Email equals g.StudentEmail
                             join adm in db.Admission_Information
                             on st.Email equals adm.Email
                             where st.Email==userName
                             select new
                             {
                                 st.UserId,
                                 st.Email,
                                 st.Full_Names,
                                 st.Surname,
                                 st.Identity_Number,
                                 g.GFull_Names,
                                 g.GSurname,
                                 g.GuardianID,
                                 g.Gcell_No,
                                 adm.Upload,
                                 
                             }).ToList();
            var viewData = new ApplicationVm();
            foreach (var item in dbRecords)
            {
                viewData.StudentId = item.UserId;
                viewData.StudentEmail = item.Email;
                viewData.StudentName = item.Full_Names;
                viewData.Surname = item.Surname;
                viewData.Identity_Number = item.Identity_Number;
                viewData.ParentName = item.GFull_Names;
                viewData.Parent_Cell = item.Gcell_No;
                viewData.Application_Status = item.Upload;
                applicationVms.Add(viewData);
            }
            Applications = applicationVms;
            return View(Applications.ToList());
        }
    }
}