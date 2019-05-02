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
    public class DetalleController : Controller
    {
        private IDetalleParticipanteService objDetalleService = new DetalleParticipanteService();
        private IAlquilerService objAlquilerService = new AlquilerService();
        private IParticipanteService objParticipanteService = new ParticipanteService();
        // GET: Detalle
        public ActionResult Index()
        {
            return View(objDetalleService.FindAll());
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            return View(objDetalleService.FindById(id));
        }

        // GET: Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ViewBag.alquiler = objAlquilerService.FindAll();
            ViewBag.participante = objParticipanteService.FindAll();
            return View(objDetalleService.FindById(id));
        }

        // POST: Detalle/Edit/5
        [HttpPost]
        public ActionResult Edit(DetalleParticipante p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ViewBag.alquiler = objAlquilerService.FindAll();
            ViewBag.participante = objParticipanteService.FindAll();
            bool rpta = false;
            rpta = objDetalleService.Update(p);
            if (rpta) return RedirectToAction("Index");
            return View();
        }

        // GET: Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            return View(objDetalleService.FindById(id));
        }

        // POST: Detalle/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objDetalleService.Delete(id);
            if(rpta)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Detalle/Create
        public ActionResult Create()
        {
            ViewBag.alquileres = objAlquilerService.FindAll();
            ViewBag.participantes= objParticipanteService.FindAll();
            return View();
        }

        // POST: Detalle/Create
        [HttpPost]
        public ActionResult Create(DetalleParticipante objDetalleParticipante)
        {

            ViewBag.alquileres = objAlquilerService.FindAll();
            ViewBag.participantes = objParticipanteService.FindAll();
            bool rpta = objDetalleService.Insertar(objDetalleParticipante);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}