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
    public class UzsakymasController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Uzsakymas
        public ActionResult Index()
        {
            var uzsakymas = db.Uzsakymas.Include(u => u.Darbuotojas).Include(u => u.Kortele).Include(u => u.Vieta);
            return View(uzsakymas.ToList());
        }

        // GET: Uzsakymas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            if (uzsakymas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakymas);
        }

        // GET: Uzsakymas/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas");
            ViewBag.fk_id_Kortele = new SelectList(db.Kortele, "id_Kortele", "Vardas");
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas");
            return View();
        }

        // POST: Uzsakymas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Uzsakymas,Data,fk_id_Vieta,fk_id_Darbuotojas,fk_id_Kortele")] Uzsakymas uzsakymas)
        {
            if (ModelState.IsValid)
            {
                db.Uzsakymas.Add(uzsakymas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas", uzsakymas.fk_id_Darbuotojas);
            ViewBag.fk_id_Kortele = new SelectList(db.Kortele, "id_Kortele", "Vardas", uzsakymas.fk_id_Kortele);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", uzsakymas.fk_id_Vieta);
            return View(uzsakymas);
        }

        // GET: Uzsakymas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            if (uzsakymas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas", uzsakymas.fk_id_Darbuotojas);
            ViewBag.fk_id_Kortele = new SelectList(db.Kortele, "id_Kortele", "Vardas", uzsakymas.fk_id_Kortele);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", uzsakymas.fk_id_Vieta);
            return View(uzsakymas);
        }

        // POST: Uzsakymas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Uzsakymas,Data,fk_id_Vieta,fk_id_Darbuotojas,fk_id_Kortele")] Uzsakymas uzsakymas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzsakymas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas", uzsakymas.fk_id_Darbuotojas);
            ViewBag.fk_id_Kortele = new SelectList(db.Kortele, "id_Kortele", "Vardas", uzsakymas.fk_id_Kortele);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", uzsakymas.fk_id_Vieta);
            return View(uzsakymas);
        }

        // GET: Uzsakymas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            if (uzsakymas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakymas);
        }

        // POST: Uzsakymas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            db.Uzsakymas.Remove(uzsakymas);
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
