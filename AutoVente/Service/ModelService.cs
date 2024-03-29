﻿using AutoVente.DAO;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Service
{
    public class ModelService : BaseServiceNom<Model>
    {
        private SqlRepositoryModel daoModel;
        public ModelService()
        {
            daoModel = new SqlRepositoryModel(new MyContext());
        }

        public override Model FindById(int id)
        {
            return daoModel.FindById(id);
        }

        internal Model FindByIdWithCouleurs(int id)
        {
            return daoModel.FindByIdWithCouleurs(id);
        }

        public override IQueryable<Model> GetAll()
        {
            return daoModel.Collection();
        }
        public List<Vehicule> FindByIdModel(int id, Carburent carburent, BoiteVitesse boiteVitesse)
        {
            return daoModel.FindByIdModel(id, carburent, boiteVitesse);
        }
        public  List<Vehicule> FindByCarburent(Carburent carburent) {
            return daoModel.FindByCarburent(carburent);
        }

        public  List<Vehicule> FindByAnnees(int dateMin, int dateMax)
        {
            return daoModel.FindByAnnees(dateMin, dateMax);
        }
       public  List<Vehicule> FindByPrix(decimal PrixMin, decimal prixMax)
        {
            return daoModel.FindByPrix(PrixMin, prixMax);
        }
        // A voir le prix affiché du veicule
        public List<Vehicule> FindByPuissanceReel(int PuissanceMin, int PuissanceMax)
        {
            return daoModel.FindByPuissanceReel(PuissanceMin, PuissanceMax);
        }
        public List<Vehicule> FindByType(Models.Type type)
        {
            List<Vehicule> vehicules = daoModel.FindByType(type);

            if (vehicules.Count> 0)
            {
                return vehicules;
            }
            else
            {
                throw new Exception("Type introuvable");
            }
        }

        public List<Vehicule> FindBoiteDeVitesse(BoiteVitesse BoiteVitesse)
        {
            return daoModel.FindBoiteDeVitesse(BoiteVitesse);
        }
        public void AddCouleurs(List<Couleur> couleurs, int IdModel)
        {
            daoModel.AddCouleurs(couleurs, IdModel);
        }
        public List<Vehicule> SearchModel( int dateMin, int dateMax, Carburent carburent, Models.Type type, BoiteVitesse boiteVitesse, int marqueId)
        {
          return  daoModel.SearchModel(dateMin, dateMax, carburent, type, boiteVitesse, marqueId);
        }
    }
}