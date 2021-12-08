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

namespace Centric_FINAL.Views
{
    public class TrackProgressesController : Controller
    {
        private Context db = new Context();

        // GET: TrackProgresses
        public ActionResult Index()
        {
            return View(db.TrackProgress.ToList());
        }

        // GET: TrackProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackProgress trackProgress = db.TrackProgress.Find(id);
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
        public ActionResult Create([Bind(Include = "TrackID,firstName,lastName,BusinessUnitName,BusinessTitle,CoreValue")] TrackProgress trackProgress)
        {
            if (ModelState.IsValid)
            {
                db.TrackProgress.Add(trackProgress);
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
            TrackProgress trackProgress = db.TrackProgress.Find(id);
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
        public ActionResult Edit([Bind(Include = "TrackID,firstName,lastName,BusinessUnitName,BusinessTitle,CoreValue")] TrackProgress trackProgress)
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
            TrackProgress trackProgress = db.TrackProgress.Find(id);
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
            TrackProgress trackProgress = db.TrackProgress.Find(id);
            db.TrackProgress.Remove(trackProgress);
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
