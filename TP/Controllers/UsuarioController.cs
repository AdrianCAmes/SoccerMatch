using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business.Implementacion;
using Business;
namespace TP.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService objUsuarioService = new UsuarioService();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(objUsuarioService.FindAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {

            return View(objUsuarioService.FindById(id));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            bool rpta = objUsuarioService.Insertar(usuario);

            if (rpta) return RedirectToAction("Index");
            return View();
        }      
    }
}
