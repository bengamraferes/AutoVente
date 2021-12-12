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
        List<Couleur> Couleurs { get; set; }
        Couleur Couleur { get; set; }
        Model Model { get; set; }

        private CouleurService Couleurservice;

        public CouleurModelViewModel()
        {
        }

        public CouleurModelViewModel(Model model)
        {
            Couleurservice = new CouleurService();
            Model = model;
            Couleurs = Couleurservice.GetAll().ToList();
            foreach (Couleur couleur in Couleurs)
            {
                foreach (Couleur couleurModel in Model.Couleurs)
                {
                    if (couleur == couleurModel)
                    {
                        this.Couleurs.Remove(couleur);
                    }
                }
            }
        }
    }
}
