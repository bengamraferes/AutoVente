using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Filter
{
    public class AuthorisationFilter : AuthorizeAttribute
    {
        private Roles[] allowedRoles;

        public AuthorisationFilter(params Roles[] allowedRoles)
        {
            this.allowedRoles = allowedRoles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            UtilisateurService service = new UtilisateurService();
            string email = Convert.ToString(httpContext.Session["email"]);
            bool isAuthorized = false;
            if (!string.IsNullOrEmpty(email))
            {
                Utilisateur user = service.GetByEmail(email);
                Roles utilisteurRole = user.Role;
                // Vérifie si le Role de l'utilsateur est dans le tableau de Roles allowedRoles
                isAuthorized = Array.Exists(allowedRoles, e => e == utilisteurRole);

            }
            return isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/Admin/NonAutoriser");
        }
    }
}