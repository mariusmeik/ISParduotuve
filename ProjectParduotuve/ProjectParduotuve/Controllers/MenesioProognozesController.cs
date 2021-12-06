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
    public class MenesioProognozesController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: MenesioProognozes
        public ActionResult Index()
        {
            return View(db.MenesioProognozes.ToList());
        }

        // GET: MenesioProognozes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenesioProognoze menesioProognoze = db.MenesioProognozes.Find(id);
            if (menesioProognoze == null)
            {
                return HttpNotFound();
            }
            return View(menesioProognoze);
        }

        // GET: MenesioProognozes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenesioProognozes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,metai,menuo,reiksmingas")] MenesioProognoze menesioProognoze)
        {
            if (ModelState.IsValid)
            {
                db.MenesioProognozes.Add(menesioProognoze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menesioProognoze);
        }

        // GET: MenesioProognozes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenesioProognoze menesioProognoze = db.MenesioProognozes.Find(id);
            if (menesioProognoze == null)
            {
                return HttpNotFound();
            }
            return View(menesioProognoze);
        }

        // POST: MenesioProognozes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,metai,menuo,reiksmingas")] MenesioProognoze menesioProognoze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menesioProognoze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menesioProognoze);
        }

        // GET: MenesioProognozes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenesioProognoze menesioProognoze = db.MenesioProognozes.Find(id);
            if (menesioProognoze == null)
            {
                return HttpNotFound();
            }
            return View(menesioProognoze);
        }

        // POST: MenesioProognozes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenesioProognoze menesioProognoze = db.MenesioProognozes.Find(id);
            db.MenesioProognozes.Remove(menesioProognoze);
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
