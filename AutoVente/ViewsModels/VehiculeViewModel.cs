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
        public List<Model> Models { get; set; }
        public List<Couleur> Couleurs { get; set; }
        public Vehicule Vehicule { get; set; }

        private CouleurService serviceCouleur;
        private ModelService serviceModel;
        private VehiculeService serviceVehicule;

        public VehiculeViewModel()
        {
            serviceCouleur = new CouleurService();
            serviceModel = new ModelService();
            serviceVehicule = new VehiculeService();

            Vehicule = new Vehicule();
            Models = serviceModel.GetAll().ToList();
            Couleurs = serviceCouleur.GetAll().ToList();
        }
    }
}