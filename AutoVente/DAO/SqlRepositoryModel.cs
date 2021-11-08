using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.DAO
{
    public class SqlRepositoryModel : SqlRepositoryNom<Model>, IRepositoryModel
    {
        public SqlRepositoryModel(MyContext dataContext) : base(dataContext)
        {
        }

        public List<Vehicule> FindBoiteDeVitesse(BoiteVitesse BoiteVitesse)
        {
            throw new NotImplementedException();
        }

        public List<Vehicule> FindByAnnees(string dateMin, string dateMax)
        {
            throw new NotImplementedException();
        }

        public List<Vehicule> FindByCarburent(Carburent carburent)
        {
            throw new NotImplementedException();
        }

        public List<Vehicule> FindByPrix(decimal PrixMin, decimal prixMax)
        {
            throw new NotImplementedException();
        }

        public List<Vehicule> FindByPuissanceReel(byte PuissanceMin, byte PuissanceMax)
        {
            throw new NotImplementedException();
        }

        public List<Vehicule> FindByType(Models.Type type)
        {
            throw new NotImplementedException();
        }
    }
}