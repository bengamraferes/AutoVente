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
    public class CouleurController : Controller
    {
        private CouleurService service;

        public CouleurController()
        {
            service = new CouleurService();
        }

        // GET: Couleur
        public ActionResult Index()
        {
            List<Couleur> couleurs = service.GetAll().OrderBy(c => c.CodeCouleur).ToList();

            return View(couleurs);
        }

        // GET: Couleur
        public ActionResult Create()
        {
            TempData["couleurAdd"] = "couleurAdd";
            TempData.Keep();

            return RedirectToAction("Index");
        }

        // POST: Couleur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Couleur couleur)
        {
            if (ModelState.IsValid)
            {
                this.AddNotification($"Couleur {couleur.Nom} ajoutée", NotificationType.SUCCESS);

                service.Insert(couleur);
                service.SaveChanges();
            }
            else
            {
                this.AddNotification("Le champ Nom est obligatoire", NotificationType.ERROR);

                TempData["couleurAdd"] = "couleurAdd";
                TempData.Keep();
            }
            return RedirectToAction("index");
        }

        // GET: Couleur
        public ActionResult Edit(int id)
        {
            Couleur couleur = service.FindById(id);
            if (couleur != null)
            {
                return View(couleur);
            }
            return HttpNotFound();
        }

        // POST: Couleur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Couleur couleur)
        {
            if (ModelState.IsValid)
            {
                service.Update(couleur);
                service.SaveChanges();
                return RedirectToAction("index");
            }
            return View(couleur);
        }

        // POST: Couleur
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            this.AddNotification($"Couleur {service.FindById(id).Nom} supprimé", NotificationType.SUCCESS);

            service.Delete(id);
            service.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}