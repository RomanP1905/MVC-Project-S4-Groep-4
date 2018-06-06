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
    public class OnderhoudsController : Controller
    {
        private WagenparkContext db = new WagenparkContext();

        // GET: Onderhouds
        public ActionResult Index()
        {
            return View(db.Onderhouds.ToList());
        }

        // GET: Onderhouds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderhoud onderhoud = db.Onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // GET: Onderhouds/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Onderhouds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "OnderhoudsDatum,OnderhoudsKosten")] Onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.Onderhouds.Add(onderhoud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(onderhoud);
        }

        // GET: Onderhouds/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderhoud onderhoud = db.Onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // POST: Onderhouds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "OnderhoudsDatum,OnderhoudsKosten")] Onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onderhoud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(onderhoud);
        }

        // GET: Onderhouds/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderhoud onderhoud = db.Onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // POST: Onderhouds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Onderhoud onderhoud = db.Onderhouds.Find(id);
            db.Onderhouds.Remove(onderhoud);
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
