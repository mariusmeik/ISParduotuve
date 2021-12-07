using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectParduotuve.Controllers
{
    public class ProognozuojamaPrekesController : Controller
    {
        // GET: ProognozuojamaPrekes
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProognozuojamaPrekes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProognozuojamaPrekes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProognozuojamaPrekes/Create
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

        // GET: ProognozuojamaPrekes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProognozuojamaPrekes/Edit/5
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

        // GET: ProognozuojamaPrekes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProognozuojamaPrekes/Delete/5
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
