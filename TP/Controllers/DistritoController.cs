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
    public class DistritoController : Controller
    {
        private IDistritoService objDistritoServicio = new DistritoService();

        private ICiudadService objCiudadService = new CiudadService();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(objDistritoServicio.FindAll());
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(objDistritoServicio.FindById(id));
        }

        // GET: Distrito/Create

         public ActionResult Create()
        {
            ViewBag.ciudades = objCiudadService.FindAll();
            return View();
        }  

        //POST: Distrito/Create
        [HttpPost]
        public ActionResult Create(Distrito objDistrito)
        {
            //ViewBag.ciudades = objCiudadService.FindAll();
            bool rpta = objDistritoServicio.Insertar(objDistrito);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
                return HttpNotFound();
            ViewBag.ciudad = objCiudadService.FindAll();
            return View(objDistritoServicio.FindById(id));
        }

        // POST: Distrito/Edit/5
        [HttpPost]
        public ActionResult Edit(Distrito d)
        {
            if (!ModelState.IsValid)
                return View();
            ViewBag.ciudad = objCiudadService.FindAll();
            bool rpta = false;
            rpta = objDistritoServicio.Update(d);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }

        public ActionResult Delete(int id)
        {
            if (id == null)
                return HttpNotFound();
            return View(objDistritoServicio.FindById(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Distrito u)
        {
            if (!ModelState.IsValid)
                return View();
            bool rpta = false;
            rpta = objDistritoServicio.Delete(u.CDistrito);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}
