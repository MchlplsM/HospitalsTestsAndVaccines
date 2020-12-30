using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalsTestsAndVaccines.Models;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class ContactDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactDetails
        public ActionResult Index()
        {
            return View(db.ContactDetails.ToList());
        }

        // GET: ContactDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetails contactDetails = db.ContactDetails.Find(id);
            if (contactDetails == null)
            {
                return HttpNotFound();
            }
            return View(contactDetails);
        }

        // GET: ContactDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,HospitalId,Phone,Address,City,PostalCode,State,Email")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                db.ContactDetails.Add(contactDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactDetails);
        }

        // GET: ContactDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetails contactDetails = db.ContactDetails.Find(id);
            if (contactDetails == null)
            {
                return HttpNotFound();
            }
            return View(contactDetails);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,HospitalId,Phone,Address,City,PostalCode,State,Email")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactDetails);
        }

        // GET: ContactDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetails contactDetails = db.ContactDetails.Find(id);
            if (contactDetails == null)
            {
                return HttpNotFound();
            }
            return View(contactDetails);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactDetails contactDetails = db.ContactDetails.Find(id);
            db.ContactDetails.Remove(contactDetails);
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
