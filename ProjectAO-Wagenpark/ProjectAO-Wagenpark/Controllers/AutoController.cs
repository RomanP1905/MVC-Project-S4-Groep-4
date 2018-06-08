using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectAO_Wagenpark.Models;

namespace ProjectAO_Wagenpark.Controllers
{
    [Authorize(Roles = "Admin , Dealer")]
    public class AutoController : Controller
    {
        private WagenparkDBModel db = new WagenparkDBModel();

        // GET: Auto
        public ActionResult Index()
        {
            var auto = db.Auto.Include(a => a.Dealer);
            return View(auto.ToList());
        }

        // GET: Auto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            ViewBag.DEALER_DealerNr = new SelectList(db.Dealer, "Dealernr", "Naam");
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Kenteken,Merk,Type,DEALER_DealerNr")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Auto.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEALER_DealerNr = new SelectList(db.Dealer, "Dealernr", "Naam", auto.DEALER_DealerNr);
            return View(auto);
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEALER_DealerNr = new SelectList(db.Dealer, "Dealernr", "Naam", auto.DEALER_DealerNr);
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Kenteken,Merk,Type,DEALER_DealerNr")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEALER_DealerNr = new SelectList(db.Dealer, "Dealernr", "Naam", auto.DEALER_DealerNr);
            return View(auto);
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auto auto = db.Auto.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Auto auto = db.Auto.Find(id);
            db.Auto.Remove(auto);
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
