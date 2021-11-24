using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class UtilisateurService : BaseServiceNom<Utilisateur>
    {
        private SqlRepositoryUtilisateur daoUtilisateur;
        public UtilisateurService()
        {
            daoUtilisateur = new SqlRepositoryUtilisateur(new MyContext());
        }

        public Utilisateur GetByEmail(string email)
        {
            return daoUtilisateur.GetByEmail(email);
        }
        public Utilisateur GetByTelephone(string telephone)
        {
            return daoUtilisateur.GetByTelephone(telephone);
        }
    }
}