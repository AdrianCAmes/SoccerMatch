using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class CanchaController : Controller
    {
        private ICanchaService objCanchaService = new CanchaService();
        // GET: Cancha
        public ActionResult Index()
        {
            return View(objCanchaService.FindAll());
        }
    }
}