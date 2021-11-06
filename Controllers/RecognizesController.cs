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

namespace Centric_FINAL.Controllers
{
    public class RecognizesController : Controller
    {
        private Context db = new Context();

        // GET: Recognizes
        public ActionResult Index()
        {
            var recognize = db.Recognize.Include(r => r.Profile);
            return View(recognize.ToList());
        }

        // GET: Recognizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognize recognize = db.Recognize.Find(id);
            if (recognize == null)
            {
                return HttpNotFound();
            }
            return View(recognize);
        }

        // GET: Recognizes/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Profile, "EmployeeID", "firstName");
            return View();
        }

        // POST: Recognizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecognizeID,EmployeeID,CoreValueIndicator,MessageOption,Message")] Recognize recognize)
        {
            if (ModelState.IsValid)
            {
                db.Recognize.Add(recognize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Profile, "EmployeeID", "firstName", recognize.EmployeeID);
            return View(recognize);
        }

        // GET: Recognizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognize recognize = db.Recognize.Find(id);
            if (recognize == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Profile, "EmployeeID", "firstName", recognize.EmployeeID);
            return View(recognize);
        }

        // POST: Recognizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecognizeID,EmployeeID,CoreValueIndicator,MessageOption,Message")] Recognize recognize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Profile, "EmployeeID", "firstName", recognize.EmployeeID);
            return View(recognize);
        }

        // GET: Recognizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognize recognize = db.Recognize.Find(id);
            if (recognize == null)
            {
                return HttpNotFound();
            }
            return View(recognize);
        }

        // POST: Recognizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognize recognize = db.Recognize.Find(id);
            db.Recognize.Remove(recognize);
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
