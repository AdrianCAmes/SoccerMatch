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
            return View(objCanchaService.FindById(id));
        }
        public ActionResult Edit(int id)
        {
            ViewBag.calle = objCalleService.FindAll();
            ViewBag.propietario = objPropietarioService.FindAll();
            return View(objCanchaService.FindById(id));
        }
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
        public ActionResult Delete(int id)
        {
            return View(objCanchaService.FindById(id));
        }

        // POST: Cancha/Delete/5
        [HttpPost]
        public ActionResult Delete(Cancha cancha)
        {
            bool rpta = false;
            rpta = objCanchaService.Delete(cancha.CCancha);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}