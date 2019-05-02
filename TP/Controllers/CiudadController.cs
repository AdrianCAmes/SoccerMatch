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
            if (id == null)
            {
                return HttpNotFound();
            }

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

        // GET: Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.departamento = objDepartamentoService.FindAll();
            return View(objCiudadService.FindById(id));
        }

        // POST: Distrito/Edit/5
        [HttpPost]
        public ActionResult Edit(Ciudad d)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewBag.departamento = objDepartamentoService.FindAll();
            bool rpta = false;
            rpta = objCiudadService.Update(d);
            if (rpta) return RedirectToAction("Index");
            return View();
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objCiudadService.FindById(id));
        }

        // POST: Ciudad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objCiudadService.Delete(id);
            if (rpta) return RedirectToAction("Index");
            return View();

        }
    }
}