using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectAO_Wagenpark.DataAccesLayer;
using ProjectAO_Wagenpark.Models;

namespace ProjectAO_Wagenpark.Controllers
{
    public class WerkplaatsController : Controller
    {
        private WagenparkContext db = new WagenparkContext();

        // GET: Werkplaats
        public ActionResult Index()
        {
            return View(db.Werkplaats.ToList());
        }

        // GET: Werkplaats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Werkplaats werkplaats = db.Werkplaats.Find(id);
            if (werkplaats == null)
            {
                return HttpNotFound();
            }
            return View(werkplaats);
        }

        // GET: Werkplaats/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Werkplaats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "WerkplaatsNr,Naam")] Werkplaats werkplaats)
        {
            if (ModelState.IsValid)
            {
                db.Werkplaats.Add(werkplaats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(werkplaats);
        }

        // GET: Werkplaats/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Werkplaats werkplaats = db.Werkplaats.Find(id);
            if (werkplaats == null)
            {
                return HttpNotFound();
            }
            return View(werkplaats);
        }

        // POST: Werkplaats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "WerkplaatsNr,Naam")] Werkplaats werkplaats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(werkplaats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(werkplaats);
        }

        // GET: Werkplaats/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Werkplaats werkplaats = db.Werkplaats.Find(id);
            if (werkplaats == null)
            {
                return HttpNotFound();
            }
            return View(werkplaats);
        }

        // POST: Werkplaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Werkplaats werkplaats = db.Werkplaats.Find(id);
            db.Werkplaats.Remove(werkplaats);
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
