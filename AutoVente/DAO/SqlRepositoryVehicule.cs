using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryVehicule : SqlRepository<Vehicule>, IRepositoryVehicule
    {// Il faut que la classe hérite de SqlRepo et implémente l'interphace SqlRepo Voiture
        public SqlRepositoryVehicule(MyContext dataContext) : base(dataContext)
        {
        }
        public List<Vehicule> FindByEtat(EtatVoiture etat)
        {
            throw new NotImplementedException();
        }

        public Vehicule FindByImmatriculation(string immatriculation)
        {
            throw new NotImplementedException();
        }

        public List<Vehicule> FindByKilometrage(int min, int max)
        {
            throw new NotImplementedException();
        }
    }
}