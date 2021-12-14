using AutoVente.Metier;
using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace AutoVente.DAO
{
    public class SqlRepositoryModel : SqlRepositoryNom<Model>, IRepositoryModel
    {
        public SqlRepositoryModel(MyContext dataContext) : base(dataContext)
        {
        }
        public override IQueryable<Model> Collection()
        {
            return dbSet.Include(m => m.Marque).Include(m =>m.Couleurs);
        }
        public List<Vehicule> FindBoiteDeVitesse(BoiteVitesse boiteVitesse)
        {
            List<Model> models = dbSet.AsNoTracking().Where(m => m.BoiteDeVitesse == boiteVitesse).ToList();
            List<Vehicule> vehicules = new List<Vehicule>();
            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }
            
            return vehicules;
        }

        public List<Vehicule> FindByAnnees(DateTime dateMin, DateTime dateMax)
        {
            List<Vehicule> vehicules = new List<Vehicule>();

            //Verifier si les 2 dates ne sont pas égales
            List<Model> models = dbSet.AsNoTracking()
                .Where(m => m.Annee.AsDateTime().Ticks >= dateMin.Ticks)
                .Where(m => m.Annee.AsDateTime().Ticks <= dateMax.Ticks).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByCarburent(Carburent carburent)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.AsNoTracking().Where(m => m.Carburent == carburent).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByPrix(decimal PrixMin, decimal prixMax)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.AsNoTracking().Where(m => m.Prix >= PrixMin && m.Prix <= prixMax).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByPuissanceReel(int PuissanceMin, int PuissanceMax)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.AsNoTracking().Where(m => m.PuissanceReel >= PuissanceMin && m.PuissanceReel <= PuissanceMax).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByType(Models.Type type)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.AsNoTracking().Where(m => m.Type == type).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }
        public void AddCouleurs( List<Couleur> couleurs ,int IdModel)
        {
            Model model = dbSet.Include(m => m.Couleurs).SingleOrDefault(m => m.Id == IdModel);
            
            
            foreach (Couleur couleur in couleurs)
            {
                model.Couleurs.Add(couleur);
               
            }
            dataContext.SaveChanges();
        }
    }
}