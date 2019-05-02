using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business.Implementacion;
using Business;
namespace TP.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService objUsuarioService = new UsuarioService();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(objUsuarioService.FindAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {

            return View(objUsuarioService.FindById(id));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            bool rpta = objUsuarioService.Insertar(usuario);

            if (rpta) return RedirectToAction("Index");
            return View();
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View(objUsuarioService.FindById(id));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario u)
        {
            bool rpta = objUsuarioService.Update(u);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objUsuarioService.FindById(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objUsuarioService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}