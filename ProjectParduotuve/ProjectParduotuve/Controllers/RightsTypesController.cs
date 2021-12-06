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
    public class RightsTypesController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: RightsTypes
        public ActionResult Index()
        {
            return View(db.RightsTypes.ToList());
        }

        // GET: RightsTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightsType rightsType = db.RightsTypes.Find(id);
            if (rightsType == null)
            {
                return HttpNotFound();
            }
            return View(rightsType);
        }

        // GET: RightsTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RightsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] RightsType rightsType)
        {
            if (ModelState.IsValid)
            {
                db.RightsTypes.Add(rightsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rightsType);
        }

        // GET: RightsTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightsType rightsType = db.RightsTypes.Find(id);
            if (rightsType == null)
            {
                return HttpNotFound();
            }
            return View(rightsType);
        }

        // POST: RightsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] RightsType rightsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rightsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rightsType);
        }

        // GET: RightsTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RightsType rightsType = db.RightsTypes.Find(id);
            if (rightsType == null)
            {
                return HttpNotFound();
            }
            return View(rightsType);
        }

        // POST: RightsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RightsType rightsType = db.RightsTypes.Find(id);
            db.RightsTypes.Remove(rightsType);
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
