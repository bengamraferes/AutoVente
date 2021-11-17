using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class CouleurService : BaseService<Couleur>
    {
        private SqlRepositoryCouleur daoCouleur;
        public CouleurService()
        {
            daoCouleur = new SqlRepositoryCouleur(new MyContext());
        }

        public Couleur FindByCode(string code)
        {
            return daoCouleur.GetByCode(code);
        }
    }
}