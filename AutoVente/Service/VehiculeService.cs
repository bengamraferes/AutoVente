using AutoVente.DAO;
using AutoVente.Models;
using AutoVente.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class VehiculeService :BaseService<Vehicule>
    {
        private SqlRepositoryVehicule daoVehicule;
        public VehiculeService()
        {
            daoVehicule = new SqlRepositoryVehicule(new MyContext());
        }

        public override IQueryable<Vehicule> GetAll()
        {
            return daoVehicule.Collection();
        }
        public List<Vehicule> GetVehiculesWithPricipalPhoto()
        {
            return daoVehicule.GetVehiculesWithPricipalPhoto();
        }
        public List<Vehicule> VehiculesVendu()
        {
            return daoVehicule.VehiculesVendu();
        }
        public Vehicule GetDetailVehicule(int id)
        {
            return daoVehicule.GetDetailVehicule(id);
        }
        public List<Vehicule> FindByEtat(EtatVoiture etat)
        {
           return daoVehicule.FindByEtat( etat);
        }

        public Vehicule FindByImmatriculation(string immatriculation)
        {
            return daoVehicule.FindByImmatriculation(immatriculation);
        }

        public List<Vehicule> FindByKilometrage(int min, int max)
        {
            return daoVehicule.FindByKilometrage(min, max);
        }
        public List<Vehicule> SearchVehicule(List<Vehicule> vehicules, int KilometrageMin, int KilometrageMax, int prixMin, int prixMax, EtatViewModel etatViewModel)
        {
            return daoVehicule.SearchVehicule(vehicules, KilometrageMin, KilometrageMax, prixMin, prixMax, etatViewModel);
        }
    }
}