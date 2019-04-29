using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
namespace TP.Controllers
{
    public class CanchaController : Controller
    {
        private ICanchaService objCanchaService = new CanchaService();
        private IPropietarioService objPropiertarioService = new PropietarioService();
        private ICalleService objCalleService = new CalleService();
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
    }
}