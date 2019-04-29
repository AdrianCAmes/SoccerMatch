using Business;
using Business.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class ParticipanteController : Controller
    {
        private IParticipanteService objParticipanteService = new ParticipanteService();
        // GET: Participante
        public ActionResult Index()
        {
            return View(objParticipanteService.FindAll());
        }

        // GET: Participante/Details/5
        public ActionResult Details(int? id)
        {
            return View(objParticipanteService.FindById(id));
        }
<<<<<<< HEAD

     
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
    }
}