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
    public class Prognazuojama_prekeController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Prognazuojama_preke
        public ActionResult Index()
        {
            var prognazuojama_preke = db.Prognazuojama_preke.Include(p => p.Menesio_prognoze).Include(p => p.Produkto_specifikacija);
            return View(prognazuojama_preke.ToList());
        }

        // GET: Prognazuojama_preke/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prognazuojama_preke prognazuojama_preke = db.Prognazuojama_preke.Find(id);
            if (prognazuojama_preke == null)
            {
                return HttpNotFound();
            }
            return View(prognazuojama_preke);
        }

        // GET: Prognazuojama_preke/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Menesio_prognoze = new SelectList(db.Menesio_prognoze, "id_Menesio_prognoze", "id_Menesio_prognoze");
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas");
            return View();
        }

        // POST: Prognazuojama_preke/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Prognazuojama_preke,Uzsakymo_kiekis,Reikalingas_kiekis,Pirkimo_prognoze,fk_id_Menesio_prognoze,fk_id_Produkto_specifikacija")] Prognazuojama_preke prognazuojama_preke)
        {
            if (ModelState.IsValid)
            {
                db.Prognazuojama_preke.Add(prognazuojama_preke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Menesio_prognoze = new SelectList(db.Menesio_prognoze, "id_Menesio_prognoze", "id_Menesio_prognoze", prognazuojama_preke.fk_id_Menesio_prognoze);
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas", prognazuojama_preke.fk_id_Produkto_specifikacija);
            return View(prognazuojama_preke);
        }

        // GET: Prognazuojama_preke/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prognazuojama_preke prognazuojama_preke = db.Prognazuojama_preke.Find(id);
            if (prognazuojama_preke == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Menesio_prognoze = new SelectList(db.Menesio_prognoze, "id_Menesio_prognoze", "id_Menesio_prognoze", prognazuojama_preke.fk_id_Menesio_prognoze);
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas", prognazuojama_preke.fk_id_Produkto_specifikacija);
            return View(prognazuojama_preke);
        }

        // POST: Prognazuojama_preke/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Prognazuojama_preke,Uzsakymo_kiekis,Reikalingas_kiekis,Pirkimo_prognoze,fk_id_Menesio_prognoze,fk_id_Produkto_specifikacija")] Prognazuojama_preke prognazuojama_preke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prognazuojama_preke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Menesio_prognoze = new SelectList(db.Menesio_prognoze, "id_Menesio_prognoze", "id_Menesio_prognoze", prognazuojama_preke.fk_id_Menesio_prognoze);
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas", prognazuojama_preke.fk_id_Produkto_specifikacija);
            return View(prognazuojama_preke);
        }

        // GET: Prognazuojama_preke/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prognazuojama_preke prognazuojama_preke = db.Prognazuojama_preke.Find(id);
            if (prognazuojama_preke == null)
            {
                return HttpNotFound();
            }
            return View(prognazuojama_preke);
        }

        // POST: Prognazuojama_preke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prognazuojama_preke prognazuojama_preke = db.Prognazuojama_preke.Find(id);
            db.Prognazuojama_preke.Remove(prognazuojama_preke);
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
