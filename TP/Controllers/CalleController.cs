using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using Entity;
=======

>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
namespace TP.Controllers
{
    public class CalleController : Controller
    {
        private ICalleService objCalleService = new CalleService();
<<<<<<< HEAD
        private IDistritoService objDistritoService = new DistritoService();
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
        // GET: Calle
        public ActionResult Index()
        {
            return View(objCalleService.FindAll());
        }

        // GET: Calle/Details/5
        public ActionResult Details(int? id)
        {
            return View(objCalleService.FindById(id));
        }
<<<<<<< HEAD

        public ActionResult Create()
        {
            ViewBag.distritos = objDistritoService.FindAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Calle objCalle)
        {
            ViewBag.distritos = objDistritoService.FindAll();
            bool rpta = objCalleService.Insertar(objCalle);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }

=======
    }
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
}