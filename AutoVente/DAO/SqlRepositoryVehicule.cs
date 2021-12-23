using AutoVente.Metier;
using AutoVente.Models;
using AutoVente.ViewsModels;
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
        public List<Vehicule> SearchVehicule(List<Vehicule> vehicules, int KilometrageMin, int KilometrageMax, int prixMin,int prixMax , EtatViewModel etatViewModel)
        {
            vehicules = vehicules.Where(v => v.Kilometrage >= KilometrageMin && v.Kilometrage <= KilometrageMax).Where(v => v.Prix >= prixMin && v.Prix <= prixMax).ToList();
            if (etatViewModel != 0)
            {
                if (etatViewModel == EtatViewModel.Neuf)
                {
                    vehicules = vehicules.Where(v => v.Etat == EtatVoiture.NEUF).ToList();
                }
                else
                {
                    vehicules = vehicules.Where(v => v.Etat != EtatVoiture.NEUF).ToList();
                }
            }
            return vehicules;
        }
    }
}