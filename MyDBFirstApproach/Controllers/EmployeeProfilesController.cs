using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDBFirstApproach.Models;

namespace MyDBFirstApproach.Controllers
{
    public class EmployeeProfilesController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: EmployeeProfiles
        public ActionResult Index()
        {
            return View(db.EmployeeProfiles.ToList());
        }

        // GET: EmployeeProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProfile employeeProfile = db.EmployeeProfiles.Find(id);
            if (employeeProfile == null)
            {
                return HttpNotFound();
            }
            return View(employeeProfile);
        }

        // GET: EmployeeProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpName,EmpSalary")] EmployeeProfile employeeProfile)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeProfiles.Add(employeeProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeProfile);
        }

        // GET: EmployeeProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProfile employeeProfile = db.EmployeeProfiles.Find(id);
            if (employeeProfile == null)
            {
                return HttpNotFound();
            }
            return View(employeeProfile);
        }

        // POST: EmployeeProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,EmpSalary")] EmployeeProfile employeeProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeProfile);
        }

        // GET: EmployeeProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProfile employeeProfile = db.EmployeeProfiles.Find(id);
            if (employeeProfile == null)
            {
                return HttpNotFound();
            }
            return View(employeeProfile);
        }

        // POST: EmployeeProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeProfile employeeProfile = db.EmployeeProfiles.Find(id);
            db.EmployeeProfiles.Remove(employeeProfile);
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
