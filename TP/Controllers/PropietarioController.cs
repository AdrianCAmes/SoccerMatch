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
            if (id == null)
                return HttpNotFound();
            return View(objPropietarioService.FindById(id));
        }

        // GET: Propietario/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            ViewBag.usuarios = objUsuarioService.FindAll();
            return View(objPropietarioService.FindById(id));
        }
        // Post: Propietario/Edit
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

        // GET: Propietario/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(objPropietarioService.FindById(id));
        }

        // POST: Propietario/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objPropietarioService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }

        // GET: Propietario/Create
        public ActionResult Create()
        {
            ViewBag.usuarios = objUsuarioService.FindAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Propietario objPropietario)
        {
            ViewBag.usuarios = objUsuarioService.FindAll();
            bool rpta = objPropietarioService.Insertar(objPropietario);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}