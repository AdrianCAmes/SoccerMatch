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
    public class DepartamentoController : Controller
    {
        private IDepartamentoService objDepartamentoService = new DepartamentoService();
        // GET: Departamento
        public ActionResult Index()
        {
            return View(objDepartamentoService.FindAll());
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objDepartamentoService.FindById(id));
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        public ActionResult Create(Departamento departamento)
        {
            bool rpta = objDepartamentoService.Insertar(departamento);

            if(rpta) return RedirectToAction("Index");
            return View();

        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objDepartamentoService.FindById(id));
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        public ActionResult Edit(Departamento d)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool rpta = false;
            rpta = objDepartamentoService.Update(d);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objDepartamentoService.FindById(id));
        }

        // POST: Departamento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objDepartamentoService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}