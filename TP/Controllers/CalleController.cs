using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class CalleController : Controller
    {
        private ICalleService objCalleService = new CalleService();
        // GET: Calle
        public ActionResult Index()
        {
            return View(objCalleService.FindAll());
        }
    }
}