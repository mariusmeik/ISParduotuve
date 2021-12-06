using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectParduotuve.Models;

namespace ProjectParduotuve.Controllers
{
    public class Produkto_specifikacijaController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Produkto_specifikacija
        public ActionResult Index()
        {
            return View(db.Produkto_specifikacija.ToList());
        }

        // GET: Produkto_specifikacija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkto_specifikacija produkto_specifikacija = db.Produkto_specifikacija.Find(id);
            if (produkto_specifikacija == null)
            {
                return HttpNotFound();
            }
            return View(produkto_specifikacija);
        }

        // GET: Produkto_specifikacija/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produkto_specifikacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Produkto_specifikacija,Pavadinimas,Svoris,Kaina,Nuolaida,Kiekis")] Produkto_specifikacija produkto_specifikacija)
        {
            if (ModelState.IsValid)
            {
                db.Produkto_specifikacija.Add(produkto_specifikacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produkto_specifikacija);
        }

        // GET: Produkto_specifikacija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkto_specifikacija produkto_specifikacija = db.Produkto_specifikacija.Find(id);
            if (produkto_specifikacija == null)
            {
                return HttpNotFound();
            }
            return View(produkto_specifikacija);
        }

        // POST: Produkto_specifikacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Produkto_specifikacija,Pavadinimas,Svoris,Kaina,Nuolaida,Kiekis")] Produkto_specifikacija produkto_specifikacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkto_specifikacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produkto_specifikacija);
        }

        // GET: Produkto_specifikacija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkto_specifikacija produkto_specifikacija = db.Produkto_specifikacija.Find(id);
            if (produkto_specifikacija == null)
            {
                return HttpNotFound();
            }
            return View(produkto_specifikacija);
        }

        // POST: Produkto_specifikacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkto_specifikacija produkto_specifikacija = db.Produkto_specifikacija.Find(id);
            db.Produkto_specifikacija.Remove(produkto_specifikacija);
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
