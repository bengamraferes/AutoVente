using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.ViewsModels
{
    public class AdresseUtilisateurViewModel
    {
        public Adresse Adresse { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}