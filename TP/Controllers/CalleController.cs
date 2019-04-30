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

        // GET: Calle/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objCalleService.FindById(id));
        }

        // POST: Calle/Delete/5
        [HttpPost]
        public ActionResult Delete(Calle calle)
        {
            bool rpta = false;
            rpta = objCalleService.Delete(calle.CCalle);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}