using AutoVente.Extensions;
using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class LoginController : Controller
    {
        private UtilisateurService service;

        public LoginController()
        {
            this.service = new UtilisateurService();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Connexion()
        {
            Utilisateur user = new Utilisateur();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion(Utilisateur user)
        {
            string msgErreur = "Echec authentification";
            if (ModelState.IsValidField("Email") && ModelState.IsValidField("Password"))
            {
                Utilisateur userDb = service.GetByEmail(user.Email);
                if (userDb != null)
                {
                    if (userDb.Password.Equals(user.Password))
                    {
                        Session["email"] = userDb.Email;
                        // Redirect to Admin selon le type
                        string root = "~/Login/Index";
                        if (userDb.Role == Roles.CLIENT)
                        {
                            root = "~/Utilisateur/Index";
                        }
                        else
                        {
                            root = "~/Admin/Index";
                        }
                        return Redirect(root);
                    }
                    else
                    {
                        msgErreur = "Mot de passe Invalide ";
                        
                    }
                }
                else
                {
                    TempData["Email"] = user.Email;
                    return Redirect("~/Utilisateur/Create");
                }
            }
            else
            {
                TempData["Email"] = user.Email;
                return Redirect("~/Utilisateur/Create");
            }

            this.AddNotification(msgErreur, NotificationType.WARNING);
            return View(user);
        }

    }
}