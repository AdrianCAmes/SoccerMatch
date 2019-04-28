using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class CiudadController : Controller
    {
        private ICiudadService objCiudadService = new CiudadService();
        // GET: Ciudad
        public ActionResult Index()
        {
            return View(objCiudadService.FindAll());
        }
    }
}