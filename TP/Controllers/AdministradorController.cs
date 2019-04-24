using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class AdministradorController : Controller
    {
        private IAdministradorService objAdministradorService = new AdministradorService();
        // GET: Administrador
        public ActionResult Index()
        {
            return View(objAdministradorService.FindAll());
        }
    }
}