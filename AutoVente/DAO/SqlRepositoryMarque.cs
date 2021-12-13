using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryMarque : SqlRepositoryNom<Marque>, IRepositoryMarque
    {
        public SqlRepositoryMarque(MyContext dataContext) : base(dataContext)
        {
        }

        

        public List<Vehicule> FindByOrigine(Origine origine)
        {
            List<Marque> marques = (List<Marque>)dbSet.AsNoTracking().Where(m => m.Origine == origine);
            List<Vehicule> vehicules = new List<Vehicule>();
            foreach (var marque in marques)
            {
                foreach (var model in marque.Models)
                {
                    vehicules.AddRange(model.Vehicules);
                }
            }
            return vehicules;
        }
    }
}