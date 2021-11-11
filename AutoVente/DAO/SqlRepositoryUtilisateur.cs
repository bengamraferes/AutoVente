using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryUtilisateur : SqlRepositoryNom<Utilisateur>, IRepositoryUtilisateur
    {
        public SqlRepositoryUtilisateur(MyContext dataContext) : base(dataContext)
        {

        }

        public Utilisateur GetByEmail(string email)
        {
            Utilisateur utilisateur = dbSet.AsNoTracking().SingleOrDefault(x => x.Email == email);

            if (utilisateur != null)
            {
                return utilisateur;
            }
            else
            {
                throw new Exception("Utilisateur introuvable");
            }
        }

        public Utilisateur GetByTelephone(string telephone)
        {
            Utilisateur utilisateur = dbSet.AsNoTracking().SingleOrDefault(x => x.Telephone == telephone);

            if (utilisateur != null)
            {
                return utilisateur;
            }
            else
            {
                throw new Exception("Utilisateur introuvable");
            }
        }

    }
}