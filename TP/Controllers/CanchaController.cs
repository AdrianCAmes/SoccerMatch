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
        private IPropietarioService objPropietarioService = new PropietarioService();
        private ICalleService objCalleService = new CalleService();
        // GET: Cancha
        public ActionResult Index()
        {
            return View(objCanchaService.FindAll());
        }

        // GET: Cancha/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objCanchaService.FindById(id));
        }

        // GET: Cancha/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.calle = objCalleService.FindAll();
            ViewBag.propietario = objPropietarioService.FindAll();
            return View(objCanchaService.FindById(id));
        }

        // POST: Cancha/Edit/5
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

        // GET: Cancha/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objCanchaService.FindById(id));
        }

        // POST: Cancha/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objCanchaService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.propietarios = objPropietarioService.FindAll();
            ViewBag.calles = objCalleService.FindAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Cancha objCancha)
        {
            ViewBag.propietarios = objPropietarioService.FindAll();
            ViewBag.calles = objCalleService.FindAll();
            bool rpta = objCanchaService.Insertar(objCancha);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}

