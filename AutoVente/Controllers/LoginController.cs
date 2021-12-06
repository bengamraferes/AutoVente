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
                        string root = "~/Admin/";
                        switch (userDb.Role)
                        {
                            case Roles.ADMNISTRATEUR:
                                root += "Administrateur";
                                break;
                            case Roles.SECRETAIRE:
                                root += "Secretaire";
                                break;
                            case Roles.UTILISATEUR:
                                root += "Utilisateur";
                                break;
                            case Roles.CLIENT:
                                root += "Client";
                                break;
                           
                        }
                        return Redirect(root);
                    }
                    else
                    {
                        msgErreur = "Mod de passe Invalide";
                        ViewBag.error = msgErreur;
                    }
                }
                else
                {
                    TempData["Email"] = user.Email;
                    return RedirectToAction("Create");
                }
            }
            else
            {
                TempData["Email"] = user.Email;
                return RedirectToAction("Create");
            }


            return View(user);
        }

    }
}