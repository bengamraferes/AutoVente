using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.ViewsModels
{
    public class CouleurModelViewModel
    {
        public List<Couleur> Couleurs { get; set; }
        public Couleur Couleur { get; set; }
        public Model Model { get; set; }
        public int Id { get; set; }
        public List<CouleurChekboxViewModel> ChekboxViewModels { get; set; }
        private CouleurService Couleurservice;

        public CouleurModelViewModel()
        {
        }

        public CouleurModelViewModel(Model model)
        {
            Couleurservice = new CouleurService();
            Model = model;
            Couleurs = Couleurservice.GetAll().ToList();
            ChekboxViewModels = new List<CouleurChekboxViewModel>();
            Id = model.Id;
           
            for (int i = 0; i < Couleurs.Count; i++)
            {
          
                if (i < Model.Couleurs.Count && Couleurs[i].Id == Model.Couleurs[i].Id)
                {
                    Couleurs.Remove(Couleurs[i]);
                }
            }
            foreach (Couleur couleur in Couleurs)
            {
                CouleurChekboxViewModel ccvm = new CouleurChekboxViewModel();
                ccvm.IdCouleur = couleur.Id;
                ChekboxViewModels.Add(ccvm);
            }

        

        }
    }
}
