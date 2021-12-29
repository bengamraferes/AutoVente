using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.ViewsModels
{
    public class VehiculeViewModel
    {
        public List<Marque> Marques { get; set; }
        public List<Model> Models { get; set; }
        public List<Couleur> Couleurs { get; set; }
        public Vehicule Vehicule { get; set; }

        private MarqueService serviceMarque;
        private ModelService serviceModel;
        private CouleurService serviceCouleur;
        private VehiculeService serviceVehicule;

        public int ModelId { get; set; }
        public int CouleurId { get; set; }
        public int Prix { get; set; }
        public List<string> Photos { get; set; }

        public VehiculeViewModel()
        {
            serviceMarque = new MarqueService();
            serviceModel = new ModelService();
            serviceCouleur = new CouleurService();
            serviceVehicule = new VehiculeService();

            Vehicule = new Vehicule();
            Marques = serviceMarque.GetAll().ToList();
            Models = serviceModel.GetAll().ToList();
            Couleurs = serviceCouleur.GetAll().ToList();
        }
    }
}