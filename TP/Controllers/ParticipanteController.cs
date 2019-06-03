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
            if (id == null)
                return HttpNotFound();
            return View(objParticipanteService.FindById(id));
        }

        // GET: Participante/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            ViewBag.jugador = objJugadorService.FindAll();
            ViewBag.grupo = objGrupoService.FindAll();
            return View(objParticipanteService.FindById(id));
        }
        // POST: Participante/Edit
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

        // GET: Participante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(objParticipanteService.FindById(id));
        }

        // POST: Participante/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objParticipanteService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
        // GET: Participante/Create
        public ActionResult Create()
        {
            ViewBag.jugadores = objJugadorService.FindAll();
            ViewBag.grupos = objGrupoService.FindAll();
            return View();
        }

        //POST: Participante/Create
        [HttpPost]
        public ActionResult Create(Participante objParticipante)
        {
            ViewBag.jugadores = objJugadorService.FindAll();
            ViewBag.grupos = objGrupoService.FindAll();
            bool rpta = objParticipanteService.Insertar(objParticipante);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}