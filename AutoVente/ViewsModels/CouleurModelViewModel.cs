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
        public List<Couleur> couleurView { get; set; }
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
            couleurView = new List<Couleur>();
         

            List<int> _couleurs = new List<int>();
           
   
            _couleurs = Couleurs.Select(c => c.Id).Except(model.Couleurs.Select(cm => cm.Id)).ToList();

            foreach (int id in _couleurs)
            {
                CouleurChekboxViewModel ccvm = new CouleurChekboxViewModel();
                ccvm.IdCouleur = id;
                ChekboxViewModels.Add(ccvm);
            }
           
            foreach ( int  id in _couleurs)
            {
               Couleur c =  Couleurservice.FindById(id);
                couleurView.Add(c);
            }

        }
    }
}
