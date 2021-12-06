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
    public class KortelesController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Korteles
        public ActionResult Index()
        {
            var kortele = db.Kortele.Include(k => k.Prisijungimas);
            return View(kortele.ToList());
        }

        // GET: Korteles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kortele kortele = db.Kortele.Find(id);
            if (kortele == null)
            {
                return HttpNotFound();
            }
            return View(kortele);
        }

        // GET: Korteles/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas");
            return View();
        }

        // POST: Korteles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Kortele,Vardas,Pavarde,El_pastas,Telefonas,Galioja_iki,Galioja_nuo,Aktyvus,fk_id_Prisijungimas")] Kortele kortele)
        {
            if (ModelState.IsValid)
            {
                db.Kortele.Add(kortele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas", kortele.fk_id_Prisijungimas);
            return View(kortele);
        }

        // GET: Korteles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kortele kortele = db.Kortele.Find(id);
            if (kortele == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas", kortele.fk_id_Prisijungimas);
            return View(kortele);
        }

        // POST: Korteles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Kortele,Vardas,Pavarde,El_pastas,Telefonas,Galioja_iki,Galioja_nuo,Aktyvus,fk_id_Prisijungimas")] Kortele kortele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kortele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Prisijungimas = new SelectList(db.Prisijungimas, "id_Prisijungimas", "Vardas", kortele.fk_id_Prisijungimas);
            return View(kortele);
        }

        // GET: Korteles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kortele kortele = db.Kortele.Find(id);
            if (kortele == null)
            {
                return HttpNotFound();
            }
            return View(kortele);
        }

        // POST: Korteles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kortele kortele = db.Kortele.Find(id);
            db.Kortele.Remove(kortele);
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
