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
    public class GrupoController : Controller
    {
        private IGrupoService objGrupoService = new GrupoService();
        private IDistritoService objDistritoService = new DistritoService();
        // GET: Grupo
        public ActionResult Index()
        {
            return View(objGrupoService.FindAll());
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();
            return View(objGrupoService.FindById(id));
        }
        // GET: Grupo/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            ViewBag.distrito = objDistritoService.FindAll();
            return View(objGrupoService.FindById(id));
        }
        // POST: Grupo/Edit
        [HttpPost]
        public ActionResult Edit(Grupo p)
        {
          
            ViewBag.usuarios = objDistritoService.FindAll();
            bool rpta = false;
            rpta = objGrupoService.Update(p);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
        // GET: Grupo/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();
            return View(objGrupoService.FindById(id));
        }

        // POST: Grupo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool rpta = false;
            rpta = objGrupoService.Delete(id);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            ViewBag.distritos = objDistritoService.FindAll();
            return View();
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(Grupo objGrupo)
        {
            ViewBag.distritos = objDistritoService.FindAll();
            bool rpta = objGrupoService.Insertar(objGrupo);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
    }
}