﻿using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Insight
{
    public class InsightModel
    {
        public List<DontValues> Origines { get; set; }
        public List<DontValues> Types { get; set; }
        public List<BarValues> ChiffresAffaires { get; set; }
        private VehiculeService ServiceVehicule;
        private BaseService<HystoriqueAchatVente> ServiceHystorique;
        private List<Vehicule> vehicules;
        private List<HystoriqueAchatVente> Hystoriques;

        public InsightModel()
        {
            ServiceVehicule = new VehiculeService();
            Origines = new List<DontValues>();
            Types = new List<DontValues>();
            ServiceHystorique = new BaseService<HystoriqueAchatVente>();
            Hystoriques = ServiceHystorique.GetAll().ToList();
            foreach(Origine origine in Enum.GetValues(typeof(Origine) )) {
                Origines.Add(new DontValues (Enum.GetName(typeof(Origine),origine), 0));
            }
            foreach (Models.Type type in Enum.GetValues(typeof(Models.Type)))
            {
                Types.Add(new DontValues(Enum.GetName(typeof(Models.Type), type), 0));
            }
            vehicules = ServiceVehicule.VehiculesVendu();
            TypesAssigneValues();
            ChiffreAffairesAssigneValues();
        }
        public void TypesAssigneValues()
        {
            int Total = 0;
            
            foreach (var vehicule in this.vehicules)
            {
                for (int i = 0; i < Types.Count(); i++)
                {
                    if (Types[i].label == Enum.GetName(typeof(Models.Type), vehicule.Model.Type))
                    {
                        this.Types[i].value++;
                        
                    }
                } 
                
            }
            foreach (var item in Types)
            {
                Total += item.value;
            }
            for (int i = 0; i < Types.Count(); i++)
            {
                int value = Types[i].value;
                int percent = (int)Math.Round((double)(100 * value) / Total);
                Types[i].value = percent;
                
            }
            
        }
        public void OrigineAssigneValues()
        {
            int Total = 0;

            foreach (var vehicule in this.vehicules)
            {
                for (int i = 0; i < Origines.Count(); i++)
                {
                    if (Origines[i].label == Enum.GetName(typeof(Origine), vehicule.Model.Marque.Origine))
                    {
                        this.Origines[i].value++;

                    }
                }

            }
            foreach (var item in Origines)
            {
                Total += item.value;
            }
            for (int i = 0; i < Origines.Count(); i++)
            {
                int value = Origines[i].value;
                int percent = (int)Math.Round((double)(100 * value) / Total);
                Origines[i].value = percent;

            }
        }
        public void ChiffreAffairesAssigneValues()
        {
            DateTime dateStart = DateTime.Now.AddDays(-365);
            DateTime dateEnd = DateTime.Now.AddDays(1).AddTicks(-1);
            //Hystoriques = 
            //Hystoriques.Where()
        }
    }
}