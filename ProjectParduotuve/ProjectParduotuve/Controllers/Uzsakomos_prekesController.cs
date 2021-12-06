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
    public class Uzsakomos_prekesController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Uzsakomos_prekes
        public ActionResult Index()
        {
            var uzsakomos_prekes = db.Uzsakomos_prekes.Include(u => u.Uzsakymas);
            return View(uzsakomos_prekes.ToList());
        }

        // GET: Uzsakomos_prekes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakomos_prekes uzsakomos_prekes = db.Uzsakomos_prekes.Find(id);
            if (uzsakomos_prekes == null)
            {
                return HttpNotFound();
            }
            return View(uzsakomos_prekes);
        }

        // GET: Uzsakomos_prekes/Create
        public ActionResult Create()
        {
            ViewBag.fk_id_Uzsakymas = new SelectList(db.Uzsakymas, "id_Uzsakymas", "id_Uzsakymas");
            return View();
        }

        // POST: Uzsakomos_prekes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Uzsakomos_prekes,Kiekis,Patvirtintas,Pakestas,Kaina,Nuolaida,fk_id_Uzsakymas")] Uzsakomos_prekes uzsakomos_prekes)
        {
            if (ModelState.IsValid)
            {
                db.Uzsakomos_prekes.Add(uzsakomos_prekes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_id_Uzsakymas = new SelectList(db.Uzsakymas, "id_Uzsakymas", "id_Uzsakymas", uzsakomos_prekes.fk_id_Uzsakymas);
            return View(uzsakomos_prekes);
        }

        // GET: Uzsakomos_prekes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakomos_prekes uzsakomos_prekes = db.Uzsakomos_prekes.Find(id);
            if (uzsakomos_prekes == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_id_Uzsakymas = new SelectList(db.Uzsakymas, "id_Uzsakymas", "id_Uzsakymas", uzsakomos_prekes.fk_id_Uzsakymas);
            return View(uzsakomos_prekes);
        }

        // POST: Uzsakomos_prekes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Uzsakomos_prekes,Kiekis,Patvirtintas,Pakestas,Kaina,Nuolaida,fk_id_Uzsakymas")] Uzsakomos_prekes uzsakomos_prekes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzsakomos_prekes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_id_Uzsakymas = new SelectList(db.Uzsakymas, "id_Uzsakymas", "id_Uzsakymas", uzsakomos_prekes.fk_id_Uzsakymas);
            return View(uzsakomos_prekes);
        }

        // GET: Uzsakomos_prekes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakomos_prekes uzsakomos_prekes = db.Uzsakomos_prekes.Find(id);
            if (uzsakomos_prekes == null)
            {
                return HttpNotFound();
            }
            return View(uzsakomos_prekes);
        }

        // POST: Uzsakomos_prekes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzsakomos_prekes uzsakomos_prekes = db.Uzsakomos_prekes.Find(id);
            db.Uzsakomos_prekes.Remove(uzsakomos_prekes);
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
