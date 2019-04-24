using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class AlquilerController : Controller
    {
        private IAlquilerService objAlquilerService = new AlquilerService();
        // GET: Alquiler
        public ActionResult Index()
        {
            return View(objAlquilerService.FindAll());
        }
    }
}