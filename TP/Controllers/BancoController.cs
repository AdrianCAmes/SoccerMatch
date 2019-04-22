using Entity;
using Service;
using Service.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Controllers
{
    public class BancoController : Controller
    {
        private IBancoService bancoService = new BancoService();
        // GET: Banco
        public ActionResult Index()
        {
            return View(bancoService.FindAll());
        }
         
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();

            }
            Banco objbanco = bancoService.FindById(id);
            return View(objbanco);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(Banco banco)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool rptaedit = bancoService.Update(banco);
            if (rptaedit)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Banco/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
