using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.ViewsModels
{
    public class ModelMarqueViewModel
    {
        public Model Model { get; set; }
        public List<Marque> Marques { get; set; }
        public Marque Marque { get; set; }
        public List<Couleur> couleurs { get; set; }

        private MarqueService serviceMarque;

        public ModelMarqueViewModel()
        {
            serviceMarque = new MarqueService();
            Marques = serviceMarque.GetAll().ToList();
        }
    }
}