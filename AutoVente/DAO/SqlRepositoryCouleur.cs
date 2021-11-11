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
            Couleur couleur = dbSet.AsNoTracking().SingleOrDefault(c => c.CodeCouleur == CodeCouleur);

            if (couleur != null)
            {
                return couleur;
            }
            else
            {
                throw new Exception("Couleur introuvable");
            }
        }
    }
}