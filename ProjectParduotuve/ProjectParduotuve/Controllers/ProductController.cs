using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectParduotuve.Models;

namespace ProjectParduotuve.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {

            List<Product> list = new List<Product>();

            list.Add(new Product());

            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {

            Product product = new Product();

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        //atidarius puslapi
        public ActionResult Edit(FormCollection fc)
        {
            Product product = new Product();
            
            return View(product);
        }

        // POST: Product/Edit/5
        //uzdarus puslapi
        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = new Product();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
