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
            throw new NotImplementedException();
        }

        public Utilisateur GetByTelephone(string telephone)
        {
            throw new NotImplementedException();
        }

    }
}