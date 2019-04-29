﻿using Business;
using Business.Implementacion;
using Entity;
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
        private IGrupoService objGrupoService = new GrupoService();
        private ICanchaService objCanchaService = new CanchaService();
        // GET: Alquiler
        public ActionResult Index()
        {
            return View(objAlquilerService.FindAll());
        }

        // GET: Alquiler/Details/5
        public ActionResult Details(int? id)
        {
            return View(objAlquilerService.FindById(id));
        }

        // GET: Alquiler/Create
        public ActionResult Create()
        {
            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();
            return View();
        }

        // POST: Alquiler/Create
        [HttpPost]
        public ActionResult Create(Alquiler alquiler)
        {
            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();

            bool rpta = objAlquilerService.Insertar(alquiler);
            
            if (rpta) return RedirectToAction("Index");
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();
            return View(objAlquilerService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(Alquiler a)
        {
            ViewBag.grupos = objGrupoService.FindAll();
            ViewBag.canchas = objCanchaService.FindAll();
            bool rpta = false;
            rpta = objAlquilerService.Update(a);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
    }
}