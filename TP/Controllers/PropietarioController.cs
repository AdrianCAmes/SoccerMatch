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
    public class PropietarioController : Controller
    {
        private IPropietarioService objPropietarioService = new PropietarioService();
        private IUsuarioService objUsuarioService = new UsuarioService();
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
        public ActionResult Edit(int id)
        {
            ViewBag.usuarios = objUsuarioService.FindAll();
            return View(objPropietarioService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Propietario p)
        {
            ViewBag.usuarios = objUsuarioService.FindAll();
            bool rpta = false;
            rpta = objPropietarioService.Update(p);
            if(rpta)
                return RedirectToAction("Index");
            return View();
        }
    }
}