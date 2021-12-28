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
        TOUT =0,
        ESSENCE = 1,
        GASOLE = 2,
        ELECTRIQUE = 3,
        HYBRIDE = 4,
    }
    public enum BoiteVitesseViewModel
    {
        TOUT = 0,
        AUTO = 1,
        MANUEL = 2
    }
    public enum TypeViewModel
    {
        TOUT = 0,
        BREAK = 1,
        CITADINE = 2,
        ROUTIERE = 3,
        SPROTIVE = 4,
        MONOSPACE = 5,
        SUV = 6,
        LUDOSPACE = 7,
        BERLINE = 8
    }
    public enum EtatViewModel
    {
        Tout = 0,
        Neuf = 1,
        Occasion =2
    }

}