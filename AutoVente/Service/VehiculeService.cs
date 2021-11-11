using AutoVente.DAO;
using AutoVente.Models;
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
    }
}