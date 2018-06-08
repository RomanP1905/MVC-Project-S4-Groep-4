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
    public class OnderhoudsController : Controller
    {
        private WagenparkDBModel db = new WagenparkDBModel();

        // GET: Onderhouds
        public ActionResult Index()
        {
            var onderhoud = db.Onderhoud.Include(o => o.Auto).Include(o => o.Werkplaats);

            //var onderhoud = from oh in db.Onderhoud
            //                 join au in db.Auto on oh.Auto_Kenteken equals au.Kenteken
            //                 join dl in db.Dealer on au.DEALER_DealerNr equals dl.Dealernr
            //                 where au.DEALER_DealerNr == dl.Dealernr
            //                 select oh;
            


            return View(onderhoud.ToList());
        }

        // GET: Onderhouds/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderhoud onderhoud = db.Onderhoud.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // GET: Onderhouds/Create
        public ActionResult Create()
        {
            ViewBag.Auto_Kenteken = new SelectList(db.Auto, "Kenteken", "Merk");
            ViewBag.Werkplaats_Werkplaatsnr = new SelectList(db.Werkplaats, "Werkplaatsnr", "Naam");
            return View();
        }

        // POST: Onderhouds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Onderhoudsdatum,Auto_Kenteken,Kosten,Werkplaats_Werkplaatsnr")] Onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.Onderhoud.Add(onderhoud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Auto_Kenteken = new SelectList(db.Auto, "Kenteken", "Merk", onderhoud.Auto_Kenteken);
            ViewBag.Werkplaats_Werkplaatsnr = new SelectList(db.Werkplaats, "Werkplaatsnr", "Naam", onderhoud.Werkplaats_Werkplaatsnr);
            return View(onderhoud);
        }

        // GET: Onderhouds/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderhoud onderhoud = db.Onderhoud.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            ViewBag.Auto_Kenteken = new SelectList(db.Auto, "Kenteken", "Merk", onderhoud.Auto_Kenteken);
            ViewBag.Werkplaats_Werkplaatsnr = new SelectList(db.Werkplaats, "Werkplaatsnr", "Naam", onderhoud.Werkplaats_Werkplaatsnr);
            return View(onderhoud);
        }

        // POST: Onderhouds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Onderhoudsdatum,Auto_Kenteken,Kosten,Werkplaats_Werkplaatsnr")] Onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onderhoud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Auto_Kenteken = new SelectList(db.Auto, "Kenteken", "Merk", onderhoud.Auto_Kenteken);
            ViewBag.Werkplaats_Werkplaatsnr = new SelectList(db.Werkplaats, "Werkplaatsnr", "Naam", onderhoud.Werkplaats_Werkplaatsnr);
            return View(onderhoud);
        }

        // GET: Onderhouds/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onderhoud onderhoud = db.Onderhoud.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // POST: Onderhouds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            Onderhoud onderhoud = db.Onderhoud.Find(id);
            db.Onderhoud.Remove(onderhoud);
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
