using Business;
using Business.Implementacion;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class DepartamentoController : Controller
    {
        private IDepartamentoService objDepartamentoService = new DepartamentoService();
        // GET: Departamento
        public ActionResult Index()
        {
            return View(objDepartamentoService.FindAll());
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int? id)
        {
            return View(objDepartamentoService.FindById(id));
        }

        // GET: Departamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        public ActionResult Create(Departamento departamento)
        {
            try
            {
                // TODO: Add insert logic here
                bool rpta = objDepartamentoService.Insertar(departamento);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}