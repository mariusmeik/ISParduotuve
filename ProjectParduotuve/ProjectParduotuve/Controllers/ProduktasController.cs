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
    public class ProduktasController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Produktas
        public ActionResult Index()
        {
            var produktas = db.Produktas.Include(p => p.Vieta).Include(p => p.Uzsakomos_prekes).Include(p => p.Produkto_specifikacija);
            return View(produktas.ToList());
        }

        // GET: Produktas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktas produktas = db.Produktas.Find(id);
            if (produktas == null)
            {
                return HttpNotFound();
            }
            return View(produktas);
        }

        // GET: Produktas/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas");
            ViewBag.fk_id_Uzsakomos_prekes = new SelectList(db.Uzsakomos_prekes, "id_Uzsakomos_prekes", "id_Uzsakomos_prekes");
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas");
            return View();
        }

        // POST: Produktas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Produktas,Pagaminimo_data,Pardavimo_data,Galiojimo_data,Kiekis,Busena,fk_id_Vieta,fk_id_Uzsakomos_prekes,fk_id_Produkto_specifikacija")] Produktas produktas)
        {
            if (ModelState.IsValid)
            {
                db.Produktas.Add(produktas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", produktas.fk_id_Vieta);
            ViewBag.fk_id_Uzsakomos_prekes = new SelectList(db.Uzsakomos_prekes, "id_Uzsakomos_prekes", "id_Uzsakomos_prekes", produktas.fk_id_Uzsakomos_prekes);
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas", produktas.fk_id_Produkto_specifikacija);
            return View(produktas);
        }

        // GET: Produktas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktas produktas = db.Produktas.Find(id);
            if (produktas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", produktas.fk_id_Vieta);
            ViewBag.fk_id_Uzsakomos_prekes = new SelectList(db.Uzsakomos_prekes, "id_Uzsakomos_prekes", "id_Uzsakomos_prekes", produktas.fk_id_Uzsakomos_prekes);
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas", produktas.fk_id_Produkto_specifikacija);
            return View(produktas);
        }

        // POST: Produktas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Produktas,Pagaminimo_data,Pardavimo_data,Galiojimo_data,Kiekis,Busena,fk_id_Vieta,fk_id_Uzsakomos_prekes,fk_id_Produkto_specifikacija")] Produktas produktas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produktas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", produktas.fk_id_Vieta);
            ViewBag.fk_id_Uzsakomos_prekes = new SelectList(db.Uzsakomos_prekes, "id_Uzsakomos_prekes", "id_Uzsakomos_prekes", produktas.fk_id_Uzsakomos_prekes);
            ViewBag.fk_id_Produkto_specifikacija = new SelectList(db.Produkto_specifikacija, "id_Produkto_specifikacija", "Pavadinimas", produktas.fk_id_Produkto_specifikacija);
            return View(produktas);
        }

        // GET: Produktas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktas produktas = db.Produktas.Find(id);
            if (produktas == null)
            {
                return HttpNotFound();
            }
            return View(produktas);
        }

        // POST: Produktas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produktas produktas = db.Produktas.Find(id);
            db.Produktas.Remove(produktas);
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
