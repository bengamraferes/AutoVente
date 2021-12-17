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
        public Models.Type Type { get; set; }

        public CarburentVioModel Carburent { get; set; }
        public BoiteVitesse BoiteVitesse { get; set; }

        public int PrixMin { get; set; }
        public int PrixMax { get; set; }

        public int AnneeMin { get; set; }
        public int AnneeMax{ get; set; }
        
        public int kilometrageMin { get; set; }
        public int kilometrageMax { get; set; }




    }
    public enum CarburentVioModel
    {
        All =0,
        ESSENCE = 1,
        GASOLE = 2,
        ELECTRIQUE = 3,
        HYBRIDE = 4,
    }
}