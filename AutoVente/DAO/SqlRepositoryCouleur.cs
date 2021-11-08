using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryCouleur : SqlRepositoryNom<Couleur>, IRepositoryCouleur
    {
        public SqlRepositoryCouleur(MyContext dataContext) : base(dataContext)
        {
        }

        public Couleur GetByCode(string CodeCouleur)
        {
            throw new NotImplementedException();
        }
    }
}