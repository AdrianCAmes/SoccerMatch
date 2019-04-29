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
<<<<<<< HEAD
using Entity;
=======

>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
>>>>>>> 9915bca4effb1a74fd0efc14a49346c36b1856f2
namespace TP.Controllers
{
    public class CalleController : Controller
    {
        private ICalleService objCalleService = new CalleService();
<<<<<<< HEAD
        private IDistritoService objDistritoService = new DistritoService();
=======
<<<<<<< HEAD
        private IDistritoService objDistritoService = new DistritoService();
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
>>>>>>> 9915bca4effb1a74fd0efc14a49346c36b1856f2
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
        public ActionResult Edit(int id)
        {
            ViewBag.distrito = objDistritoService.FindAll();
            return View(objCalleService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Calle c)
        {
            ViewBag.distrito = objDistritoService.FindAll();
            bool rpta = false;
            rpta = objCalleService.Update(c);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
=======
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
>>>>>>> 9915bca4effb1a74fd0efc14a49346c36b1856f2
    }
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
}