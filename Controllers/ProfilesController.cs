using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centric_FINAL.DAL;
using Centric_FINAL.Models;
using PagedList;
using PagedList.Mvc;

namespace Centric_FINAL.Controllers
{
   [Authorize] public class ProfilesController : Controller
    {
        private Context db = new Context();

        // GET: Profiles
        public ActionResult Index(int? page)
        {
            int pgSize = 10;
            int pageNumber = (page ?? 1);
            var profile = db.Profile.OrderBy(p => p.lastName).ThenBy(p => p.firstName);
            var profileList = profile.ToPagedList(pageNumber, pgSize);
            return View(profileList);
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? page, string searchString)
        {
            int pgSize = 10;
            int pageNumber = (page ?? 1);
            var profile = from p in db.Profile select p; 

            profile = db.Profile.OrderBy(p => p.lastName).ThenBy(p => p.firstName); ;

            if (!String.IsNullOrEmpty(searchString))
            {
                profile = profile.Where(p => p.lastName.Contains(searchString) || p.firstName.Contains(searchString));
            }
            var profileList = profile.ToPagedList(pageNumber, pgSize);
            return View(profileList); 
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,firstName,lastName,BusinessUnit,hireDate,Title,email,Phone")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,firstName,lastName,BusinessUnit,hireDate,Title,email,Phone")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profile.Find(id);
            db.Profile.Remove(profile);
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
