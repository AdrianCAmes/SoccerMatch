using Business;
using Business.Implementacion;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class CiudadController : Controller
    {
        private ICiudadService objCiudadService = new CiudadService();
        private IDepartamentoService objDepartamentoService = new DepartamentoService();
        // GET: Ciudad
        public ActionResult Index()
        {
            return View(objCiudadService.FindAll());
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int? id)
        {
            return View(objCiudadService.FindById(id));
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            ViewBag.departamento = objDepartamentoService.FindAll();
            return View();
        }

        // POST: Ciudad/Create
        [HttpPost]
        public ActionResult Create(Ciudad ciudad)
        {  
            ViewBag.departamento = objDepartamentoService.FindAll();

            bool rpta = objCiudadService.Insertar(ciudad);

            if(rpta) return RedirectToAction("Index");
            return View();
           
        }
        public ActionResult Edit(int id)
        {
            ViewBag.departamento = objDepartamentoService.FindAll();
            return View(objCiudadService.FindById(id));
        }

        // POST: Distrito/Edit/5
        [HttpPost]
        public ActionResult Edit(Ciudad d)
        {
            ViewBag.departamento = objDepartamentoService.FindAll();
            bool rpta = false;
            rpta = objCiudadService.Update(d);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objCiudadService.FindById(id));
        }

        // POST: Ciudad/Delete/5
        [HttpPost]
        public ActionResult Delete(Ciudad ciudad)
        {
            bool rpta = false;
            rpta = objCiudadService.Delete(ciudad.CCiudad);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}