using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryVehicule : SqlRepository<Vehicule>, IRepositoryVehicule
    {// Il faut que la classe hérite de SqlRepo et implémente l'interphace SqlRepo Voiture
        public SqlRepositoryVehicule(MyContext dataContext) : base(dataContext)
        {
        }

        public override IQueryable<Vehicule> Collection()
        {
            return dbSet.Include(v => v.Model).Include(v => v.Model.Marque).Include(v => v.Couleur);
        }

        public List<Vehicule> FindByEtat(EtatVoiture etat)
        {
            List<Vehicule> vehicules = dbSet.AsNoTracking().Where(v => v.Etat == etat).ToList();

            return vehicules;
        }

        public Vehicule FindByImmatriculation(string immatriculation)
        {
            return dbSet.AsNoTracking().SingleOrDefault(v => v.Immatriculation == immatriculation);
        }

        public List<Vehicule> FindByKilometrage(int min, int max)
        {
            List<Vehicule> vehicules = dbSet.AsNoTracking().Where(v => v.Kilometrage >= min && v.Kilometrage <= max).ToList();

            return vehicules;
        }
    }
}