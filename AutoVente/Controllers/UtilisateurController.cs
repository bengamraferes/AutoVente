using AutoVente.Extensions;
using AutoVente.Filter;
using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class UtilisateurController : Controller
    {
        // GET: Utilisateur
        private UtilisateurService service;

        public UtilisateurController()
        {
            this.service = new UtilisateurService();
        }
        [AuthorisationFilter(Roles.CLIENT)]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            Utilisateur utilisateur = new Utilisateur();

            return View(utilisateur);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(Utilisateur user)
        {
            if (ModelState.IsValid)
            {
                user.Role = Roles.CLIENT;
                service.Insert(user);
                service.SaveChanges();
                this.AddNotification("Bienvenue" + user.Prenom,NotificationType.SUCCESS);
                return RedirectToAction("Index", user);
            }
            else
            {
                this.AddNotification("Echec de creation", NotificationType.WARNING);
                return View(user);

            }
        }
    }
}