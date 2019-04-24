using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class GrupoController : Controller
    {
        private IGrupoService objGrupoService = new GrupoService();
        // GET: Grupo
        public ActionResult Index()
        {
            return View(objGrupoService.FindAll());
        }
    }
}