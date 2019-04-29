using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Business;
using Business.Implementacion;
namespace TP.Controllers
{
    public class DistritoController : Controller
    {
        private IDistritoService objDistritoServicio = new DistritoService();
<<<<<<< HEAD
        private ICiudadService objCiudadService = new CiudadService();
=======
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
        // GET: Distrito
        public ActionResult Index()
        {
            return View(objDistritoServicio.FindAll());
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            return View(objDistritoServicio.FindById(id));
        }

        // GET: Distrito/Create
<<<<<<< HEAD
         public ActionResult Create()
         {
            ViewBag.ciudades = objCiudadService.FindAll();
             return View();
         }
=======
       /* public ActionResult Create()
        {
            return View();
        }
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9

        //POST: Distrito/Create
        [HttpPost]
        public ActionResult Create(Distrito objDistrito)
        {
            ViewBag.ciudades = objCiudadService.FindAll();
            bool rpta = objDistritoServicio.Insertar(objDistrito);

            if (rpta) return RedirectToAction("Index");
            return View();
        }
        /*
         // GET: Distrito/Edit/5
         public ActionResult Edit(int id)
         {
             return View();
         }

         // POST: Distrito/Edit/5
         [HttpPost]
         public ActionResult Edit(int id, FormCollection collection)
         {
             try
             {
                 // TODO: Add update logic here

                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }

         // GET: Distrito/Delete/5
         public ActionResult Delete(int id)
         {
             return View();
         }

         // POST: Distrito/Delete/5
         [HttpPost]
         public ActionResult Delete(int id, FormCollection collection)
         {
             try
             {
                 // TODO: Add delete logic here

<<<<<<< HEAD
                 return RedirectToAction("Index");
             }
             catch
             {
                 return View();
             }
         }*/
=======
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
>>>>>>> 30c09a7da3ce45b58043cfa1425d7f5b096d4ac9
    }
}
