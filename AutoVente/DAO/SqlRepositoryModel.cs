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

        public override Model FindById(int id)
        {
            Model obj = dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);

            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception($"{obj.GetType()} introuvable");
            }
        }

        public Model FindByIdWithCouleurs(int id)
        {
            Model obj = dbSet.AsNoTracking().Include(m => m.Couleurs).SingleOrDefault(x => x.Id == id);

            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception($"{obj.GetType()} introuvable");
            }
        }

        public override IQueryable<Model> Collection()
        {
            return dbSet.Include(m => m.Marque).Include(m =>m.Couleurs);
        }
        public List<Vehicule> FindByIdModel(int id, Carburent carburent, BoiteVitesse boiteVitesse)
        {
            List<Vehicule> Vehicules = dbSet.AsNoTracking().Include(m => m.Vehicules).SingleOrDefault(m => m.Id == id).Vehicules;
            if (carburent != 0)
            {
                Vehicules = Vehicules.Where(m => m.Model.Carburent == carburent).ToList();
            }

            if (boiteVitesse != 0)
            {
                Vehicules = Vehicules.Where(m => m.Model.BoiteDeVitesse == boiteVitesse).ToList();
            }

            return Vehicules;

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

        public List<Vehicule> FindByAnnees(int dateMin, int dateMax)
        {
            List<Vehicule> vehicules = new List<Vehicule>();

            //Verifier si les 2 dates ne sont pas égales
            List<Model> models = dbSet.Include(m => m.Vehicules).AsNoTracking().Where(m => m.Annee >= dateMin && m.Annee <= dateMax).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByCarburent(Carburent carburent)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.Include(m => m.Vehicules).AsNoTracking().Where(m => m.Carburent == carburent).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByPrix(decimal PrixMin, decimal prixMax)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.Include(m => m.Vehicules).AsNoTracking().Where(m => m.Prix >= PrixMin && m.Prix <= prixMax).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByPuissanceReel(int PuissanceMin, int PuissanceMax)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.Include(m => m.Vehicules).AsNoTracking().Where(m => m.PuissanceReel >= PuissanceMin && m.PuissanceReel <= PuissanceMax).ToList();

            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;
        }

        public List<Vehicule> FindByType(Models.Type type)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.Include(m => m.Vehicules).AsNoTracking().Where(m => m.Type == type).ToList();

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
        public List<Vehicule> SearchModel( int dateMin, int dateMax, Carburent carburent, Models.Type type, BoiteVitesse boiteVitesse, int marqueId)
        {
            List<Vehicule> vehicules = new List<Vehicule>();
            List<Model> models = dbSet.Include(m => m.Vehicules).AsNoTracking().Where(m => m.Annee >= dateMin && m.Annee <= dateMax).ToList();
            if (marqueId != 0)
            {
                models = models.Where(m => m.MarqueId == marqueId).ToList();
            }
            if (carburent != 0)
            {
                models = models.Where(m => m.Carburent == carburent).ToList();
            }
            if (type != 0)
            {
                models = models.Where(m => m.Type == type).ToList();
            }
            if (boiteVitesse != 0)
            {
                models = models.Where(m => m.BoiteDeVitesse == boiteVitesse).ToList();
            }
            foreach (var model in models)
            {
                vehicules.AddRange(model.Vehicules);
            }

            return vehicules;

        }
    }
}