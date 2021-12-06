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
    public class PrisijungimasController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: Prisijungimas
        public ActionResult Index()
        {
            return View(db.Prisijungimas.ToList());
        }

        // GET: Prisijungimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisijungimas prisijungimas = db.Prisijungimas.Find(id);
            if (prisijungimas == null)
            {
                return HttpNotFound();
            }
            return View(prisijungimas);
        }

        // GET: Prisijungimas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prisijungimas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Prisijungimas,Vardas,Slaptazodis,Teises")] Prisijungimas prisijungimas)
        {
            if (ModelState.IsValid)
            {
                db.Prisijungimas.Add(prisijungimas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prisijungimas);
        }

        // GET: Prisijungimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisijungimas prisijungimas = db.Prisijungimas.Find(id);
            if (prisijungimas == null)
            {
                return HttpNotFound();
            }
            return View(prisijungimas);
        }

        // POST: Prisijungimas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Prisijungimas,Vardas,Slaptazodis,Teises")] Prisijungimas prisijungimas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prisijungimas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prisijungimas);
        }

        // GET: Prisijungimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prisijungimas prisijungimas = db.Prisijungimas.Find(id);
            if (prisijungimas == null)
            {
                return HttpNotFound();
            }
            return View(prisijungimas);
        }

        // POST: Prisijungimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prisijungimas prisijungimas = db.Prisijungimas.Find(id);
            db.Prisijungimas.Remove(prisijungimas);
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
