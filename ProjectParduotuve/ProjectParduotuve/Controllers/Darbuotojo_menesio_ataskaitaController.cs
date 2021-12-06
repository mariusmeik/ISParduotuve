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
    public class Darbuotojo_menesio_ataskaitaController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Darbuotojo_menesio_ataskaita
        public ActionResult Index()
        {
            var darbuotojo_menesio_ataskaita = db.Darbuotojo_menesio_ataskaita.Include(d => d.Darbuotojas).Include(d => d.Vieta);
            return View(darbuotojo_menesio_ataskaita.ToList());
        }

        // GET: Darbuotojo_menesio_ataskaita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojo_menesio_ataskaita darbuotojo_menesio_ataskaita = db.Darbuotojo_menesio_ataskaita.Find(id);
            if (darbuotojo_menesio_ataskaita == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojo_menesio_ataskaita);
        }

        // GET: Darbuotojo_menesio_ataskaita/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas");
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas");
            return View();
        }

        // POST: Darbuotojo_menesio_ataskaita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Darbuotojo_menesio_ataskaita,Metai,Menuo,Dirba_nuo_h,Dirba_iki_h,Darbo_dienos,Atlyginimas,Pelnas,Pareigos,fk_id_Vieta,fk_id_Darbuotojas")] Darbuotojo_menesio_ataskaita darbuotojo_menesio_ataskaita)
        {
            if (ModelState.IsValid)
            {
                db.Darbuotojo_menesio_ataskaita.Add(darbuotojo_menesio_ataskaita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas", darbuotojo_menesio_ataskaita.fk_id_Darbuotojas);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", darbuotojo_menesio_ataskaita.fk_id_Vieta);
            return View(darbuotojo_menesio_ataskaita);
        }

        // GET: Darbuotojo_menesio_ataskaita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojo_menesio_ataskaita darbuotojo_menesio_ataskaita = db.Darbuotojo_menesio_ataskaita.Find(id);
            if (darbuotojo_menesio_ataskaita == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas", darbuotojo_menesio_ataskaita.fk_id_Darbuotojas);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", darbuotojo_menesio_ataskaita.fk_id_Vieta);
            return View(darbuotojo_menesio_ataskaita);
        }

        // POST: Darbuotojo_menesio_ataskaita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Darbuotojo_menesio_ataskaita,Metai,Menuo,Dirba_nuo_h,Dirba_iki_h,Darbo_dienos,Atlyginimas,Pelnas,Pareigos,fk_id_Vieta,fk_id_Darbuotojas")] Darbuotojo_menesio_ataskaita darbuotojo_menesio_ataskaita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darbuotojo_menesio_ataskaita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Darbuotojas = new SelectList(db.Darbuotojas, "id_Darbuotojas", "Vardas", darbuotojo_menesio_ataskaita.fk_id_Darbuotojas);
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", darbuotojo_menesio_ataskaita.fk_id_Vieta);
            return View(darbuotojo_menesio_ataskaita);
        }

        // GET: Darbuotojo_menesio_ataskaita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojo_menesio_ataskaita darbuotojo_menesio_ataskaita = db.Darbuotojo_menesio_ataskaita.Find(id);
            if (darbuotojo_menesio_ataskaita == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojo_menesio_ataskaita);
        }

        // POST: Darbuotojo_menesio_ataskaita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Darbuotojo_menesio_ataskaita darbuotojo_menesio_ataskaita = db.Darbuotojo_menesio_ataskaita.Find(id);
            db.Darbuotojo_menesio_ataskaita.Remove(darbuotojo_menesio_ataskaita);
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
