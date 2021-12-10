using AutoVente.Extensions;
using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class MarqueController : Controller
    {
        // GET: Marque
        private MarqueService service;

        public MarqueController()
        {
           service = new MarqueService();
        }

        public ActionResult Index()
        {
            List<Marque> marques = service.GetAll().OrderBy(m => m.Nom).ToList(); 
            return View(marques);
        }
        public ActionResult Edit(int id)
        {
            Marque marque = service.FindById(id);
            if (marque != null)
            {
                TempData["EditMarque"] = "EditMarque";
                TempData["IdMarque"] = marque.Id;
                TempData.Keep();
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Marque marque)
        {
            if (ModelState.IsValid)
            {
             
                service.Update(marque);
                service.SaveChanges();
                this.AddNotification("La Marque " + marque.Nom + " a été modifiée", NotificationType.SUCCESS);
            }
            else
            {
                TempData["EditMarque"] = "EditMarque";
                TempData["IdMarque"] = marque.Id;
                TempData.Keep();
                this.AddNotification("Echec de mise à jour de la Marque " + marque.Nom, NotificationType.ERROR);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            service.Delete(id);
            service.SaveChanges();
            return RedirectToAction("index");
        }
    }
}