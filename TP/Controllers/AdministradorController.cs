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
    public class AdministradorController : Controller
    {
        private IAdministradorService objAdministradorService = new AdministradorService();
        // GET: Administrador
        public ActionResult Index()
        {
            return View(objAdministradorService.FindAll());
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            return View(objAdministradorService.FindById(id));
        }
        public ActionResult Edit(int id)
        {
            return View(objAdministradorService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Administrador a)
        {
            bool rpta = objAdministradorService.Update(a);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
        
        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View(objAdministradorService.FindById(id));
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        public ActionResult Delete(Administrador administrador)
        {
            bool rpta = false;
            rpta = objAdministradorService.Delete(administrador.CUsuario);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}