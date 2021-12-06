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
    public class ProductSpecsController : Controller
    {
        private ITEntities1 db = new ITEntities1();

        // GET: ProductSpecs
        public ActionResult Index()
        {
            return View(db.ProductSpecs.ToList());
        }

        // GET: ProductSpecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpec productSpec = db.ProductSpecs.Find(id);
            if (productSpec == null)
            {
                return HttpNotFound();
            }
            return View(productSpec);
        }

        // GET: ProductSpecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSpecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,weight,price,discount,count")] ProductSpec productSpec)
        {
            if (ModelState.IsValid)
            {
                db.ProductSpecs.Add(productSpec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productSpec);
        }

        // GET: ProductSpecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpec productSpec = db.ProductSpecs.Find(id);
            if (productSpec == null)
            {
                return HttpNotFound();
            }
            return View(productSpec);
        }

        // POST: ProductSpecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,weight,price,discount,count")] ProductSpec productSpec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSpec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productSpec);
        }

        // GET: ProductSpecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSpec productSpec = db.ProductSpecs.Find(id);
            if (productSpec == null)
            {
                return HttpNotFound();
            }
            return View(productSpec);
        }

        // POST: ProductSpecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSpec productSpec = db.ProductSpecs.Find(id);
            db.ProductSpecs.Remove(productSpec);
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
