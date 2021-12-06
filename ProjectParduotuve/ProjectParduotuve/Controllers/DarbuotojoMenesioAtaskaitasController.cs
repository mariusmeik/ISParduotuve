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
    public class DarbuotojoMenesioAtaskaitasController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: DarbuotojoMenesioAtaskaitas
        public ActionResult Index()
        {
            return View(db.DarbuotojoMenesioAtaskaitas.ToList());
        }

        // GET: DarbuotojoMenesioAtaskaitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DarbuotojoMenesioAtaskaita darbuotojoMenesioAtaskaita = db.DarbuotojoMenesioAtaskaitas.Find(id);
            if (darbuotojoMenesioAtaskaita == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojoMenesioAtaskaita);
        }

        // GET: DarbuotojoMenesioAtaskaitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DarbuotojoMenesioAtaskaitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,metai,menuo,dirbaNuoH,dirbaIkiH,darboDienos,atlyginimas,pelnas,pareigos")] DarbuotojoMenesioAtaskaita darbuotojoMenesioAtaskaita)
        {
            if (ModelState.IsValid)
            {
                db.DarbuotojoMenesioAtaskaitas.Add(darbuotojoMenesioAtaskaita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(darbuotojoMenesioAtaskaita);
        }

        // GET: DarbuotojoMenesioAtaskaitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DarbuotojoMenesioAtaskaita darbuotojoMenesioAtaskaita = db.DarbuotojoMenesioAtaskaitas.Find(id);
            if (darbuotojoMenesioAtaskaita == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojoMenesioAtaskaita);
        }

        // POST: DarbuotojoMenesioAtaskaitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,metai,menuo,dirbaNuoH,dirbaIkiH,darboDienos,atlyginimas,pelnas,pareigos")] DarbuotojoMenesioAtaskaita darbuotojoMenesioAtaskaita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darbuotojoMenesioAtaskaita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(darbuotojoMenesioAtaskaita);
        }

        // GET: DarbuotojoMenesioAtaskaitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DarbuotojoMenesioAtaskaita darbuotojoMenesioAtaskaita = db.DarbuotojoMenesioAtaskaitas.Find(id);
            if (darbuotojoMenesioAtaskaita == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojoMenesioAtaskaita);
        }

        // POST: DarbuotojoMenesioAtaskaitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DarbuotojoMenesioAtaskaita darbuotojoMenesioAtaskaita = db.DarbuotojoMenesioAtaskaitas.Find(id);
            db.DarbuotojoMenesioAtaskaitas.Remove(darbuotojoMenesioAtaskaita);
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
