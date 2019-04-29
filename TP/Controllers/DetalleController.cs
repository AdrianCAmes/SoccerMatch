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
    public class DetalleController : Controller
    {
        private IDetalleParticipanteService objDetalleService = new DetalleParticipanteService();
        private IAlquilerService objAlquilerService = new AlquilerService();
        private IParticipanteService objParticipanteService = new ParticipanteService();
        // GET: Detalle
        public ActionResult Index()
        {
            return View(objDetalleService.FindAll());
        }

        // GET: Detalle/Details/5
        public ActionResult Details(int? id)
        {
            return View(objDetalleService.FindById(id));
        }
        public ActionResult Edit(int id)
        {
            ViewBag.alquiler = objAlquilerService.FindAll();
            ViewBag.participante = objParticipanteService.FindAll();
            return View(objDetalleService.FindById(id));
        }
        [HttpPost]
        public ActionResult Edit(DetalleParticipante p)
        {
            ViewBag.alquiler = objAlquilerService.FindAll();
            ViewBag.participante = objParticipanteService.FindAll();
            bool rpta = false;
            rpta = objDetalleService.Update(p);
            if (rpta)
                return RedirectToAction("Index");
            return View();
        }
    }
}