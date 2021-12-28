using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = AutoVente.Models.Type;

namespace AutoVente.Metier
{
   public  interface IRepositoryModel :IRepositoryNom<Model>
    {
        List<Vehicule> FindByCarburent(Carburent carburent);
        List<Vehicule> FindByAnnees(int dateMin, int dateMax);
        List<Vehicule> FindByPrix(decimal PrixMin, decimal prixMax);// A voir le prix affiché du veicule
        List<Vehicule> FindByPuissanceReel(int PuissanceMin, int PuissanceMax);
        List<Vehicule> FindByType(Type type);
        List<Vehicule> FindBoiteDeVitesse(BoiteVitesse BoiteVitesse);
        void AddCouleurs(List<Couleur> couleurs, int IdModel);

    }
}
