using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryCouleur : SqlRepositoryNom<Couleur>, IRepositoryCouleur
    {
        public SqlRepositoryCouleur(MyContext dataContext) : base(dataContext)
        {
        }

        public override IQueryable<Couleur> Collection()
        {

            return dbSet.Include(c => c.Models).Include(c => c.Vehicules);



        }

        public override Couleur FindById(int id)
        {
            Couleur obj = dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception($"{obj.GetType()} introuvable");
            }
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