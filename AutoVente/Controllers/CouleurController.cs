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
            Couleur couleur = new Couleur();
            return View(couleur);
        }

        // POST: Couleur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Couleur couleur)
        {
            if (ModelState.IsValid)
            {
                service.Insert(couleur);
                service.SaveChanges();
                return RedirectToAction("index");
            }
            return View(couleur);
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

        // GET: Couleur
        public ActionResult Delete(int id)
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
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            service.Delete(id);
            service.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}