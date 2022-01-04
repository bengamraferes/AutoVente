using AutoVente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.ViewsModels
{
    public class SearchViewModel
    {
        public List<Model> Models { get; set; }
        public List<Marque> Marques { get; set; }
        public List<Vehicule> Vehicules { get; set; }
        public int MarqueId { get; set; }
        public int ModelId { get; set; }
        public TypeViewModel Type { get; set; }

        public CarburentViewModel Carburent { get; set; }
        public BoiteVitesseViewModel BoiteVitesse { get; set; }
        public EtatViewModel Etat { get; set; }

        public int PrixMin { get; set; }
        public int PrixMax { get; set; }

        public int AnneeMin { get; set; }
        public int AnneeMax{ get; set; }
        
        public int kilometrageMin { get; set; }
        public int kilometrageMax { get; set; }




    }
    public enum CarburentViewModel
    {
        Tout =0,
        Essence = 1,
        Gasole = 2,
        Electrique = 3,
        Hybride = 4,
    }
    public enum BoiteVitesseViewModel
    {
        Tout = 0,
        Automatique = 1,
        Manuel = 2
    }
    public enum TypeViewModel
    {
        Tout = 0,
        Breack = 1,
        Citadine = 2,
        Routiere = 3,
        Sportive = 4,
        Monospace = 5,
        Suv = 6,
        Ludospace = 7,
        Berline = 8
    }
    public enum EtatViewModel
    {
        Tout = 0,
        Neuf = 1,
        Occasion =2
    }

}