using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using Entity;
=======

>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
namespace TP.Controllers
{
    public class DetalleController : Controller
    {
        private IDetalleParticipanteService objDetalleService = new DetalleParticipanteService();
<<<<<<< HEAD
        private IParticipanteService objParticipanteService = new ParticipanteService();
        private IAlquilerService objAlquilerService = new AlquilerService();
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
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
<<<<<<< HEAD
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
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
    }
}