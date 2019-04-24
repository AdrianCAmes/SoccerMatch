using Business;
using Business.Implementacion;
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
    }
}