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
    public class Menesio_prognozeController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Menesio_prognoze
        public ActionResult Index()
        {
            var menesio_prognoze = db.Menesio_prognoze.Include(m => m.Vieta);
            return View(menesio_prognoze.ToList());
        }

        // GET: Menesio_prognoze/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menesio_prognoze menesio_prognoze = db.Menesio_prognoze.Find(id);
            if (menesio_prognoze == null)
            {
                return HttpNotFound();
            }
            return View(menesio_prognoze);
        }

        // GET: Menesio_prognoze/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas");
            return View();
        }

        // POST: Menesio_prognoze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Menesio_prognoze,Metai,Menuo,Diena,Laikas,Reiksmingas,fk_id_Vieta")] Menesio_prognoze menesio_prognoze)
        {
            if (ModelState.IsValid)
            {
                db.Menesio_prognoze.Add(menesio_prognoze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", menesio_prognoze.fk_id_Vieta);
            return View(menesio_prognoze);
        }

        // GET: Menesio_prognoze/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menesio_prognoze menesio_prognoze = db.Menesio_prognoze.Find(id);
            if (menesio_prognoze == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", menesio_prognoze.fk_id_Vieta);
            return View(menesio_prognoze);
        }

        // POST: Menesio_prognoze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Menesio_prognoze,Metai,Menuo,Diena,Laikas,Reiksmingas,fk_id_Vieta")] Menesio_prognoze menesio_prognoze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menesio_prognoze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Vieta = new SelectList(db.Vieta, "id_Vieta", "Pavadinimas", menesio_prognoze.fk_id_Vieta);
            return View(menesio_prognoze);
        }

        // GET: Menesio_prognoze/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menesio_prognoze menesio_prognoze = db.Menesio_prognoze.Find(id);
            if (menesio_prognoze == null)
            {
                return HttpNotFound();
            }
            return View(menesio_prognoze);
        }

        // POST: Menesio_prognoze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menesio_prognoze menesio_prognoze = db.Menesio_prognoze.Find(id);
            db.Menesio_prognoze.Remove(menesio_prognoze);
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
