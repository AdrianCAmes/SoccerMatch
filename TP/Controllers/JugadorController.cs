using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class JugadorController : Controller
    {
        private IJugadorService objJugadorService = new JugadorService();
        // GET: Jugador
        public ActionResult Index()
        {
            return View(objJugadorService.FindAll());
        }
    }
}