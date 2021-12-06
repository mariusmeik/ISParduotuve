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
    public class DarbuotojasController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Darbuotojas
        public ActionResult Index()
        {
            var darbuotojas = db.Darbuotojas.Include(d => d.Prisijungimas).Include(d => d.Vieta);
            return View(darbuotojas.ToList());
        }

        // GET: Darbuotojas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas");
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas");
            return View();
        }

        // POST: Darbuotojas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Darbuotojas,Vardas,Pavarde,El_pastas,Telefonas,Dirba_nuo,Dirba_iki,Aktyvus,Pareigos,fk_id_Prisijungimas,fk_id_Vieta")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Darbuotojas.Add(darbuotojas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas", darbuotojas.fk_id_Prisijungimas);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", darbuotojas.fk_id_Vieta);
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas", darbuotojas.fk_id_Prisijungimas);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", darbuotojas.fk_id_Vieta);
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Darbuotojas,Vardas,Pavarde,El_pastas,Telefonas,Dirba_nuo,Dirba_iki,Aktyvus,Pareigos,fk_id_Prisijungimas,fk_id_Vieta")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darbuotojas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas", darbuotojas.fk_id_Prisijungimas);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", darbuotojas.fk_id_Vieta);
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            db.Darbuotojas.Remove(darbuotojas);
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
