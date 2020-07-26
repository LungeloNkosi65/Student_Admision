using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admission.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Admission.Controllers
{
    public class Admission_InformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admission_Information
        public ActionResult Index()
        {
            return View(db.Admission_Information.ToList());
        }

        // GET: Admission_Information/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admission_Information admission_Information = db.Admission_Information.Find(id);
            if (admission_Information == null)
            {
                return HttpNotFound();
            }
            return View(admission_Information);
        }

        // GET: Admission_Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admission_Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Email,Dtae,previous_school,class_admitted,address,Upload")] Admission_Information admission_Information)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserName();
                admission_Information.UserId = Guid.NewGuid().ToString();
                admission_Information.Email = userId;
                admission_Information.Dtae = DateTime.Now.Date;
                admission_Information.Upload = "Waitiing Admision";
                db.Admission_Information.Add(admission_Information);
                db.SaveChanges();
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction("Index", "Home");
            }

            return View(admission_Information);
        }

        // GET: Admission_Information/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admission_Information admission_Information = db.Admission_Information.Find(id);
            if (admission_Information == null)
            {
                return HttpNotFound();
            }
            return View(admission_Information);
        }

        // POST: Admission_Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Email,Dtae,previous_school,class_admitted,address,Upload")] Admission_Information admission_Information)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.GetUserName();
                admission_Information.Email = userName;
                admission_Information.Dtae = DateTime.Now.Date;

                db.Entry(admission_Information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admission_Information);
        }

        // GET: Admission_Information/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admission_Information admission_Information = db.Admission_Information.Find(id);
            if (admission_Information == null)
            {
                return HttpNotFound();
            }
            return View(admission_Information);
        }

        // POST: Admission_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Admission_Information admission_Information = db.Admission_Information.Find(id);
            db.Admission_Information.Remove(admission_Information);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AcceptStudent(string id)
        {
            var newState = new Admission_Information();
            var dbRecord = db.Admission_Information.Find(id);
            dbRecord.Upload = "Admited";
            newState = dbRecord;
            db.Entry(dbRecord).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeclineStudent(string id)
        {
            var newState = new Admission_Information();
            var dbRecord = db.Admission_Information.Find(id);
            dbRecord.Upload = "Declined";
            newState = dbRecord;
            db.Entry(dbRecord).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
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
