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
    public class BusenaEnumsController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: BusenaEnums
        public ActionResult Index()
        {
            return View(db.BusenaEnums.ToList());
        }

        // GET: BusenaEnums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusenaEnum busenaEnum = db.BusenaEnums.Find(id);
            if (busenaEnum == null)
            {
                return HttpNotFound();
            }
            return View(busenaEnum);
        }

        // GET: BusenaEnums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusenaEnums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,busena")] BusenaEnum busenaEnum)
        {
            if (ModelState.IsValid)
            {
                db.BusenaEnums.Add(busenaEnum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busenaEnum);
        }

        // GET: BusenaEnums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusenaEnum busenaEnum = db.BusenaEnums.Find(id);
            if (busenaEnum == null)
            {
                return HttpNotFound();
            }
            return View(busenaEnum);
        }

        // POST: BusenaEnums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,busena")] BusenaEnum busenaEnum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busenaEnum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busenaEnum);
        }

        // GET: BusenaEnums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusenaEnum busenaEnum = db.BusenaEnums.Find(id);
            if (busenaEnum == null)
            {
                return HttpNotFound();
            }
            return View(busenaEnum);
        }

        // POST: BusenaEnums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusenaEnum busenaEnum = db.BusenaEnums.Find(id);
            db.BusenaEnums.Remove(busenaEnum);
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
