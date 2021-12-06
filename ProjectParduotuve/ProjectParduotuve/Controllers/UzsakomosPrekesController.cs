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
    public class UzsakomosPrekesController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: UzsakomosPrekes
        public ActionResult Index()
        {
            return View(db.UzsakomosPrekes.ToList());
        }

        // GET: UzsakomosPrekes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UzsakomosPrekes uzsakomosPrekes = db.UzsakomosPrekes.Find(id);
            if (uzsakomosPrekes == null)
            {
                return HttpNotFound();
            }
            return View(uzsakomosPrekes);
        }

        // GET: UzsakomosPrekes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UzsakomosPrekes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kiekis,Patvirtintas,pakeistas,kaina,Nuolaida")] UzsakomosPrekes uzsakomosPrekes)
        {
            if (ModelState.IsValid)
            {
                db.UzsakomosPrekes.Add(uzsakomosPrekes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uzsakomosPrekes);
        }

        // GET: UzsakomosPrekes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UzsakomosPrekes uzsakomosPrekes = db.UzsakomosPrekes.Find(id);
            if (uzsakomosPrekes == null)
            {
                return HttpNotFound();
            }
            return View(uzsakomosPrekes);
        }

        // POST: UzsakomosPrekes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kiekis,Patvirtintas,pakeistas,kaina,Nuolaida")] UzsakomosPrekes uzsakomosPrekes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzsakomosPrekes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uzsakomosPrekes);
        }

        // GET: UzsakomosPrekes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UzsakomosPrekes uzsakomosPrekes = db.UzsakomosPrekes.Find(id);
            if (uzsakomosPrekes == null)
            {
                return HttpNotFound();
            }
            return View(uzsakomosPrekes);
        }

        // POST: UzsakomosPrekes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UzsakomosPrekes uzsakomosPrekes = db.UzsakomosPrekes.Find(id);
            db.UzsakomosPrekes.Remove(uzsakomosPrekes);
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
