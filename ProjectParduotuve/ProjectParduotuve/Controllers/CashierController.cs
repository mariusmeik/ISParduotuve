using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectParduotuve.Models;

namespace ProjectParduotuve.Controllers
{
    public class CashierController : Controller
    {
        // GET: Cashier
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cashier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cashier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cashier/Create
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

        // GET: Cashier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cashier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Cashier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cashier/Delete/5
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
