using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centric_FINAL.Models;

namespace Centric_FINAL.Controllers
{
    public class TrackProgressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrackProgresses
        public ActionResult Index()
        {
            return View(db.TrackProgresses.ToList());
        }

        // GET: TrackProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackProgress trackProgress = db.TrackProgresses.Find(id);
            if (trackProgress == null)
            {
                return HttpNotFound();
            }
            return View(trackProgress);
        }

        // GET: TrackProgresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackProgresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgressID")] TrackProgress trackProgress)
        {
            if (ModelState.IsValid)
            {
                db.TrackProgresses.Add(trackProgress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trackProgress);
        }

        // GET: TrackProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackProgress trackProgress = db.TrackProgresses.Find(id);
            if (trackProgress == null)
            {
                return HttpNotFound();
            }
            return View(trackProgress);
        }

        // POST: TrackProgresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgressID")] TrackProgress trackProgress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackProgress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trackProgress);
        }

        // GET: TrackProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackProgress trackProgress = db.TrackProgresses.Find(id);
            if (trackProgress == null)
            {
                return HttpNotFound();
            }
            return View(trackProgress);
        }

        // POST: TrackProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackProgress trackProgress = db.TrackProgresses.Find(id);
            db.TrackProgresses.Remove(trackProgress);
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
