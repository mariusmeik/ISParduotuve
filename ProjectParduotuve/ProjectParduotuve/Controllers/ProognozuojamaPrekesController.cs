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
    public class ProognozuojamaPrekesController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: ProognozuojamaPrekes
        public ActionResult Index()
        {
            return View(db.ProognozuojamaPrekes.ToList());
        }

        // GET: ProognozuojamaPrekes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProognozuojamaPreke proognozuojamaPreke = db.ProognozuojamaPrekes.Find(id);
            if (proognozuojamaPreke == null)
            {
                return HttpNotFound();
            }
            return View(proognozuojamaPreke);
        }

        // GET: ProognozuojamaPrekes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProognozuojamaPrekes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,reikalingasKiekis,pirkimoProognoze")] ProognozuojamaPreke proognozuojamaPreke)
        {
            if (ModelState.IsValid)
            {
                db.ProognozuojamaPrekes.Add(proognozuojamaPreke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proognozuojamaPreke);
        }

        // GET: ProognozuojamaPrekes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProognozuojamaPreke proognozuojamaPreke = db.ProognozuojamaPrekes.Find(id);
            if (proognozuojamaPreke == null)
            {
                return HttpNotFound();
            }
            return View(proognozuojamaPreke);
        }

        // POST: ProognozuojamaPrekes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,reikalingasKiekis,pirkimoProognoze")] ProognozuojamaPreke proognozuojamaPreke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proognozuojamaPreke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proognozuojamaPreke);
        }

        // GET: ProognozuojamaPrekes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProognozuojamaPreke proognozuojamaPreke = db.ProognozuojamaPrekes.Find(id);
            if (proognozuojamaPreke == null)
            {
                return HttpNotFound();
            }
            return View(proognozuojamaPreke);
        }

        // POST: ProognozuojamaPrekes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProognozuojamaPreke proognozuojamaPreke = db.ProognozuojamaPrekes.Find(id);
            db.ProognozuojamaPrekes.Remove(proognozuojamaPreke);
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
