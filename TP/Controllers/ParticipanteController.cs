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
    public class ParticipanteController : Controller
    {
        private IParticipanteService objParticipanteService = new ParticipanteService();
        private IJugadorService objJugadorService = new JugadorService();
        private IGrupoService objGrupoService = new GrupoService();
        // GET: Participante
        public ActionResult Index()
        {
            return View(objParticipanteService.FindAll());
        }

        // GET: Participante/Details/5
        public ActionResult Details(int? id)
        {
            return View(objParticipanteService.FindById(id));
        }
        public ActionResult Edit(int id)
        {
            ViewBag.jugador = objJugadorService.FindAll();
            ViewBag.grupo = objGrupoService.FindAll();
            return View(objParticipanteService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Participante p)
        {
            ViewBag.jugador = objJugadorService.FindAll();
            ViewBag.grupo = objGrupoService.FindAll();
            bool rpta = false;
            rpta = objParticipanteService.Update(p);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View(objParticipanteService.FindById(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Participante u)
        {
            bool rpta = false;
            rpta = objParticipanteService.Delete(u.CParticipante);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
    }
}