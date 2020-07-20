using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admission.Models;
using Microsoft.AspNet.Identity;

namespace Admission.Controllers
{
    public class StudentInformationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentInformations
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: StudentInformations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentInformation = db.Students.Find(id);
            if (studentInformation == null)
            {
                return HttpNotFound();
            }
            return View(studentInformation);
        }

        // GET: StudentInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Email,Surname,Full_Names,Identity_Number,Gender,postal_address,Image")] StudentInformation studentInformation, HttpPostedFileBase img_upload)
        {
            if (img_upload != null && img_upload.ContentLength > 0)
            {
                studentInformation.ImageType = Path.GetExtension(img_upload.FileName);
                studentInformation.Image = ConvertToBytes(img_upload);
            }
            if (ModelState.IsValid)
            {
                studentInformation.UserId = Guid.NewGuid().ToString();
                studentInformation.Email = User.Identity.GetUserName();
                db.Students.Add(studentInformation);
                db.SaveChanges();
                return RedirectToAction("Create", "Guardians");
            }

            return View(studentInformation);
        }

        //Image
        // Convert file to binary
        public byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            BinaryReader reader = new BinaryReader(file.InputStream);
            return reader.ReadBytes((int)file.ContentLength);
        }
        //Image
        //Display File
        public FileStreamResult RenderImage(string id)
        {
            MemoryStream ms = null;

            var item = db.Students.FirstOrDefault(x => x.UserId == id);
            if (item != null)
            {
                ms = new MemoryStream(item.Image);
            }
            return new FileStreamResult(ms, item.ImageType);
        }

        // GET: StudentInformations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentInformation = db.Students.Find(id);
            if (studentInformation == null)
            {
                return HttpNotFound();
            }
            return View(studentInformation);
        }

        // POST: StudentInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Email,Surname,Full_Names,Identity_Number,Gender,postal_address,Image")] StudentInformation studentInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentInformation);
        }

        // GET: StudentInformations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentInformation = db.Students.Find(id);
            if (studentInformation == null)
            {
                return HttpNotFound();
            }
            return View(studentInformation);
        }

        // POST: StudentInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentInformation studentInformation = db.Students.Find(id);
            db.Students.Remove(studentInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
