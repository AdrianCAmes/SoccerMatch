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
    public class CanchaController : Controller
    {
        private ICanchaService objCanchaService = new CanchaService();
<<<<<<< HEAD
        private IPropietarioService objPropietarioService = new PropietarioService();
        private ICalleService objCalleService = new CalleService();
=======
<<<<<<< HEAD
        private IPropietarioService objPropiertarioService = new PropietarioService();
        private ICalleService objCalleService = new CalleService();
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
>>>>>>> 9915bca4effb1a74fd0efc14a49346c36b1856f2
        // GET: Cancha
        public ActionResult Index()
        {
            return View(objCanchaService.FindAll());
        }

        // GET: Cancha/Details/5
        public ActionResult Details(int? id)
        {
            return View(objCanchaService.FindById(id));
        }
<<<<<<< HEAD
        public ActionResult Edit(int id)
        {
            ViewBag.calle = objCalleService.FindAll();
            ViewBag.propietario = objPropietarioService.FindAll();
            return View(objCanchaService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Cancha c)
        {
            ViewBag.calle = objCalleService.FindAll();
            ViewBag.propietario = objPropietarioService.FindAll();
            bool rpta = false;
            rpta = objCanchaService.Update(c);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
=======
<<<<<<< HEAD

        public ActionResult Create()
        {
            ViewBag.propietarios = objPropiertarioService.FindAll();
            ViewBag.calles = objCalleService.FindAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Cancha objCancha)
        {
            ViewBag.propietarios = objPropiertarioService.FindAll();
            ViewBag.calles = objCalleService.FindAll();
            bool rpta = objCanchaService.Insertar(objCancha);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
>>>>>>> 9915bca4effb1a74fd0efc14a49346c36b1856f2
    }
}