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
        private IDistritoService objServicio = new DistritoService();
        // GET: Distrito
        public ActionResult Index()
        {
            return View(objServicio.FindAll());
        }

        // GET: Distrito/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distrito/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Distrito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Distrito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
