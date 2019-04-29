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
<<<<<<< HEAD
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
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
=======
<<<<<<< HEAD

     
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
>>>>>>> 9915bca4effb1a74fd0efc14a49346c36b1856f2
    }
}