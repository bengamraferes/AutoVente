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
    public class AdminController : Controller
    {
        // GET: Admin
        private UtilisateurService utilisateurService;

        public AdminController()
        {
            this.utilisateurService = new UtilisateurService();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllUtilisateurs()
        {
          
            List<Utilisateur> utilisateurs = utilisateurService.GetAll().OrderBy(u => u.Nom).ToList();
            return View(utilisateurs);
        }
        public ActionResult EditUtilisateur(int id)
        {
            Utilisateur user = utilisateurService.FindById(id);
            if (user != null)
            {
                TempData["EditUtilisateur"] = "EditUtilisateur";
                TempData["IdUtilisateur"] = user.Id;
                TempData.Keep();
            }
            return RedirectToAction("AllUtilisateurs");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUtilisateur([Bind(Include = "Id,Nom,Prenom,Email,Role,Telephone")] Utilisateur user)
        {
            if (ModelState.IsValidField("Nom") && ModelState.IsValidField("Prenom") && ModelState.IsValidField("Email") && ModelState.IsValidField("Telephone") && ModelState.IsValidField("Role"))
            {
                Utilisateur userDb = utilisateurService.FindById(user.Id);
                userDb.Nom = user.Nom;
                userDb.Prenom = user.Prenom;
                userDb.Role = user.Role;
                userDb.Email = user.Email;
                userDb.Telephone = user.Telephone;
                utilisateurService.Update(userDb);
                utilisateurService.SaveChanges();
                this.AddNotification("L'utilisateur " + user.Nom +" a été modifiée", NotificationType.SUCCESS);
            }
            else
            {
                TempData["EditUtilisateur"] = "EditUtilisateur";
                TempData["Id"] = user.Id;
                TempData.Keep();
                this.AddNotification("Echec de mise à jour de l'utilisateur " + user.Nom , NotificationType.ERROR);
            }
            return RedirectToAction("AllUtilisateurs");
        }
     
        [HttpPost]
        [ActionName("DeleteUtilisateur")]
        public ActionResult ConfirmDeleteUtilisateur(int id)
        {
            utilisateurService.Delete(id);
            utilisateurService.SaveChanges();
            return RedirectToAction("AllUtilisateurs");
        }
    }
}