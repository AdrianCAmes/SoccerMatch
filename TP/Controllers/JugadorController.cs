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
    public class JugadorController : Controller
    {
        private IJugadorService objJugadorService = new JugadorService();
        private IUsuarioService objUsuarioService = new UsuarioService();
        // GET: Jugador
        public ActionResult Index()
        {
            return View(objJugadorService.FindAll());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(objJugadorService.FindById(id));
        }
        // GET: Jugador/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            ViewBag.usuarios = objUsuarioService.FindAll();
            return View(objJugadorService.FindById(id));
        }
        // POST: Jugador/Edit
        [HttpPost]
        public ActionResult Edit(Jugador c)
        {
            if (!ModelState.IsValid)
                return View();
            ViewBag.usuarios = objUsuarioService.FindAll();
            bool rpta = false;
            rpta = objJugadorService.Update(c);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
        // GET: Jugador/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(objJugadorService.FindById(id));
        }

        // POST: Jugador/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objJugadorService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
        // GET: Jugador/Create
        public ActionResult Create()
        {
            ViewBag.usuarios = objUsuarioService.FindAll();
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(Jugador objJugador)
        {
            ViewBag.usuarios = objUsuarioService.FindAll();
            bool rpta = objJugadorService.Insertar(objJugador);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}