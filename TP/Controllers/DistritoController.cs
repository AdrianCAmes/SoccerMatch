using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;
namespace TP.Controllers
{
    public class DistritoController : Controller
    {
        private IDistritoService objDistritoServicio = new DistritoService();

        private ICiudadService objCiudadService = new CiudadService();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(objDistritoServicio.FindAll());
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            return View(objDistritoServicio.FindById(id));
        }

        // GET: Distrito/Create

         public ActionResult Create()
        {
            ViewBag.ciudades = objCiudadService.FindAll();
            return View();
        }  

        //POST: Distrito/Create
        [HttpPost]
        public ActionResult Create(Distrito objDistrito)
        {
            ViewBag.ciudades = objCiudadService.FindAll();
            bool rpta = objDistritoServicio.Insertar(objDistrito);

            if (rpta) return RedirectToAction("Index");
            return View();
        }

    }
}
