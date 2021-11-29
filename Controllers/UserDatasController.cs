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
using Microsoft.AspNet.Identity;

namespace Centric_FINAL.Controllers
{
    public class UserDatasController : Controller
    {
        private Context db = new Context();

        // GET: UserDatas
        public ActionResult Index()
        {
            return View(db.UserDatas.ToList());
        }

        // GET: UserDatas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: UserDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,BusinessUnit,Title,hireDate")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userData.ID = Guid.NewGuid();
                db.UserDatas.Add(userData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userData);
        }

        // GET: UserDatas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: UserDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,firstName,lastName,PhoneNumber,BusinessUnit,Title,hireDate")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userData);
        }

        // GET: UserDatas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserData userData = db.UserDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: UserDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UserData userData = db.UserDatas.Find(id);
            db.UserDatas.Remove(userData);
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
