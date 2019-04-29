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
        private ICalleService objCalleService = new CalleService();
        // GET: Jugador
        public ActionResult Index()
        {
            return View(objJugadorService.FindAll());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int? id)
        {
            return View(objJugadorService.FindById(id));
        }
        public ActionResult Edit(int id)
        {
            ViewBag.calle = objCalleService.FindAll();
            return View(objJugadorService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Jugador c)
        {
            ViewBag.calle = objCalleService.FindAll();
            bool rpta = false;
            rpta = objJugadorService.Update(c);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
    }
}