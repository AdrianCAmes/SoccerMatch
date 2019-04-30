﻿using Business;
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
            return View(objGrupoService.FindById(id));
        }
        public ActionResult Edit(int id)
        {
            ViewBag.distrito = objDistritoService.FindAll();
            return View(objGrupoService.FindById(id));
        }
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
        public ActionResult Delete(int id)
        {
            return View(objGrupoService.FindById(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Grupo u)
        {
            bool rpta = false;
            rpta = objGrupoService.Delete(u.CGrupo);
            if (rpta)
                return RedirectToAction("Index");
            return View();

        }
        public ActionResult Create()
        {
            ViewBag.distritos = objDistritoService.FindAll();
            return View();
        }

        //POST: Distrito/Create
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