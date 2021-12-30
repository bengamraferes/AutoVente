using AutoVente.Extensions;
using AutoVente.Filter;
using AutoVente.Models;
using AutoVente.Service;
using AutoVente.ViewsModels;
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
        [AuthorisationFilter(Roles.CLIENT,Roles.ADMINISTRATEUR)]
        public ActionResult Index( Utilisateur utilisateur)
        {
            RedirectToAction("Seach", "Home");
            List<Vehicule> vehiculesFavories = utilisateur.Favories;
            return View(vehiculesFavories);
        }
       
     
        public ActionResult Create()
        {
            Utilisateur utilisateur = new Utilisateur();
            Adresse adresse = new Adresse();
            AdresseUtilisateurViewModel adresseUtilisateurViewModel = new AdresseUtilisateurViewModel { Adresse = adresse, Utilisateur = utilisateur };


            return View(adresseUtilisateurViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create(AdresseUtilisateurViewModel adresseUtilisateurViewModel)
        {
            Utilisateur user = adresseUtilisateurViewModel.Utilisateur;
            Adresse adresse = adresseUtilisateurViewModel.Adresse;
            user.Adresse = adresse;
            if (ModelState.IsValid)
            {
                user.Role = Roles.CLIENT;
                service.Insert(user);
                service.SaveChanges();
                this.AddNotification("Bienvenue" + user.Prenom,NotificationType.SUCCESS);
                return Redirect("~/Login/Connexion");
            }
            else
            {
                this.AddNotification("Echec de creation", NotificationType.WARNING);
                return View(user);

            }
        }
    }
}