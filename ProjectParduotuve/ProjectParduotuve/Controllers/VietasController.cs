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
    public class VietasController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Vietas
        public ActionResult Index()
        {
            return View(db.Vieta.ToList());
        }

        // GET: Vietas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vieta vieta = db.Vieta.Find(id);
            if (vieta == null)
            {
                return HttpNotFound();
            }
            return View(vieta);
        }

        // GET: Vietas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vietas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Vieta,Pavadinimas,Adresas,Paskirtis")] Vieta vieta)
        {
            if (ModelState.IsValid)
            {
                db.Vieta.Add(vieta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vieta);
        }

        // GET: Vietas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vieta vieta = db.Vieta.Find(id);
            if (vieta == null)
            {
                return HttpNotFound();
            }
            return View(vieta);
        }

        // POST: Vietas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Vieta,Pavadinimas,Adresas,Paskirtis")] Vieta vieta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vieta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vieta);
        }

        // GET: Vietas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vieta vieta = db.Vieta.Find(id);
            if (vieta == null)
            {
                return HttpNotFound();
            }
            return View(vieta);
        }

        // POST: Vietas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vieta vieta = db.Vieta.Find(id);
            db.Vieta.Remove(vieta);
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
