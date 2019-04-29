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
    public class CalleController : Controller
    {
        private ICalleService objCalleService = new CalleService();
        private IDistritoService objDistritoService = new DistritoService();
        // GET: Calle
        public ActionResult Index()
        {
            return View(objCalleService.FindAll());
        }

        // GET: Calle/Details/5
        public ActionResult Details(int? id)
        {
            return View(objCalleService.FindById(id));
        }

        public ActionResult Create()
        {
            ViewBag.distritos = objDistritoService.FindAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Calle objCalle)
        {
            ViewBag.distritos = objDistritoService.FindAll();
            bool rpta = objCalleService.Insertar(objCalle);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }

}