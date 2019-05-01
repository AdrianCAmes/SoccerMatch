using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;

namespace TP.Controllers
{
    public class CalleController : Controller
    {
        private ICalleService objCalleService = new CalleService();

        private IDistritoService objDistritoService = new DistritoService();

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
        // GET: Calle/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objCalleService.FindById(id));
        }

        [HttpPost]
        public ActionResult Delete(Calle calle)
        {
            bool rpta = false;
            rpta = objCalleService.Delete(calle.CCalle);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
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
    }

    }




