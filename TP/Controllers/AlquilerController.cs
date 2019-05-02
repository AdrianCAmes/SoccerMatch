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
    public class AlquilerController : Controller
    {
        private IAlquilerService objAlquilerService = new AlquilerService();
        private IGrupoService objGrupoService = new GrupoService();
        private ICanchaService objCanchaService = new CanchaService();
        // GET: Alquiler
        public ActionResult Index()
        {
            return View(objAlquilerService.FindAll());
        }

        // GET: Alquiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objAlquilerService.FindById(id));
        }

        // GET: Alquiler/Create
        public ActionResult Create()
        {
            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();
            return View();
        }

        // POST: Alquiler/Create
        [HttpPost]
        public ActionResult Create(Alquiler alquiler)
        {
            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();

            bool rpta = objAlquilerService.Insertar(alquiler);
            
            if (rpta) return RedirectToAction("Index");
            return View();
        }

        // GET: Alquiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();
            return View(objAlquilerService.FindById(id));
        }

        // POST: Alquiler/Edit/5
        [HttpPost]
        public ActionResult Edit(Alquiler a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();
            bool rpta = false;
            rpta = objAlquilerService.Update(a);
            if (rpta) return RedirectToAction("Index");
            return View();
        }

        // GET: Alquiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objAlquilerService.FindById(id));
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objAlquilerService.Delete(id);
            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}