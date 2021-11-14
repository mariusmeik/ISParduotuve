using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectParduotuve.Models;

namespace ProjectParduotuve.Controllers
{
    public class WorkerController : Controller
    {
        // GET: Worker
        public ActionResult Index()
        {
            List<Worker> list = new List<Worker>();

            list.Add(new Worker() { id = 1 } );
            
            return View(list);
        }

        // GET: Worker/Details/5
        public ActionResult Details(int id)
        {
            Worker worker = new Worker();

            return View(worker);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worker/Create
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

        // GET: Worker/Edit/5
        public ActionResult Edit(int id)
        {
            Worker worker = new Worker();

            return View(worker);
        }

        // POST: Worker/Edit/5
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

        // GET: Worker/Delete/5
        public ActionResult Delete(int id)
        {
            Worker worker = new Worker();

            return View(worker);
        }

        // POST: Worker/Delete/5
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
