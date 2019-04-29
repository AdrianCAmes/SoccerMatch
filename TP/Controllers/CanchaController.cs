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
    public class CanchaController : Controller
    {
        private ICanchaService objCanchaService = new CanchaService();
<<<<<<< HEAD
        private IPropietarioService objPropiertarioService = new PropietarioService();
        private ICalleService objCalleService = new CalleService();
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
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
    }
}