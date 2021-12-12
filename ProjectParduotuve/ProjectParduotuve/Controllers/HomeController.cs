using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectParduotuve.Models;

namespace ProjectParduotuve.Controllers
{
    public class HomeController : Controller
    {

        private ITEntities1 db = new ITEntities1();
        // GET: Product/Edit/5
        //atidarius puslapi
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            try
            {
                Prisijungimas prisijungimas = db.Prisijungimas.SqlQuery("Select * From Prisijungimas Where Vardas='" + fc["username"] + "' And Slaptazodis='" + fc["password"]+"'").First();
                if (prisijungimas != null)
                {
                    Session["user"] = prisijungimas.Vardas;
                    Session["password"] = prisijungimas.Slaptazodis;
                    Session["rights"] = prisijungimas.Teises;
                }
            }
            catch {

            }
            
            //cheat 
            if (true) {
                Session["user"] = "Admin";
                Session["password"] = "Admin";
                Session["rights"] = "Admin";
            }

            return RedirectToAction("index", "Main");
            //return View();
        }

        public ActionResult Register(FormCollection fc)
        {
            int seed = DateTime.Now.Year * 100*60*24*365 + DateTime.Now.Day*100*60*24+ DateTime.Now.Minute*100 + DateTime.Now.Millisecond;
            Random random = new Random(seed);
            if (fc["vardas"] != "" && fc["password"] != "") {
                db.Prisijungimas.SqlQuery("INSERT INTO `prisijungimas`(`id_Prisijungimas`,`Vardas`, `Slaptazodis`, `Teises`) VALUES (" + seed + ",'" + fc["vardas"] + "','" + fc["password"] + "','" + fc["right"] + "')");
                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "Vardas,Slaptazodis")] Prisijungimas prisijungimas)
        {
            //return RedirectToAction("Index");
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
