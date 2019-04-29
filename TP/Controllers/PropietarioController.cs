using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class PropietarioController : Controller
    {
        private IPropietarioService objPropietarioService = new PropietarioService();
        // GET: Propietario
        public ActionResult Index()
        {
            return View(objPropietarioService.FindAll());
        }

        // GET: Propietario/Details/5
        public ActionResult Details(int? id)
        {
            return View(objPropietarioService.FindById(id));
        }
    }
}