using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1;

namespace SourceControlAssignment1.Controllers
{
    public class tbl_registrationController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: tbl_registration
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: tbl_registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registration tbl_registration = db.Users.Find(id);
            if (tbl_registration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registration);
        }

        // GET: tbl_registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Address,DateOfBirth,Email,Password,ConfirmPassword,Phone")] tbl_registration tbl_registration)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(tbl_registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_registration);
        }

        // GET: tbl_registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registration tbl_registration = db.Users.Find(id);
            if (tbl_registration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registration);
        }

        // POST: tbl_registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Address,DateOfBirth,Email,Password,ConfirmPassword,Phone")] tbl_registration tbl_registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_registration);
        }

        // GET: tbl_registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_registration tbl_registration = db.Users.Find(id);
            if (tbl_registration == null)
            {
                return HttpNotFound();
            }
            return View(tbl_registration);
        }

        // POST: tbl_registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_registration tbl_registration = db.Users.Find(id);
            db.Users.Remove(tbl_registration);
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
