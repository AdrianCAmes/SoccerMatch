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
        private IParticipanteService objParticipanteService = new ParticipanteService();
        private IAlquilerService objAlquilerService = new AlquilerService();
        // GET: Detalle
        public ActionResult Index()
        {
            return View(objDetalleService.FindAll());
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int? id)
        {
            return View(objDetalleService.FindById(id));
        }
        //public ActionResult Create()
        //{
        //    ViewBag.participantes = objParticipanteService.FindAll();
        //    ViewBag.alquileres= objAlquilerService.FindAll();
        //    return View();
        //}

        //// POST: Usuario/Create
        //[HttpPost]
        //public ActionResult Create(DetalleParticipante objDetalle)
        //{
        //    ViewBag.participantes = objParticipanteService.FindAll();
        //    ViewBag.alquileres = objAlquilerService.FindAll();
        //    bool rpta = objDetalleService.Insertar(objDetalle);

        //    if (rpta) return RedirectToAction("Index");
        //    return View();
        //}
    }
}