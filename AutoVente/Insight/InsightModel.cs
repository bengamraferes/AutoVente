using AutoVente.Models;
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
        private VehiculeService ServiceVehicule;
        private List<Vehicule> vehicules;
        public InsightModel()
        {
            ServiceVehicule = new VehiculeService();
            Origines = new List<DontValues>();
            foreach(Origine origine in Enum.GetValues(typeof(Origine) )) {
                Origines.Add(new DontValues (Enum.GetName(typeof(Origine),origine), 0));
            }
            
          


        }
        public void OrigineAssigneValues()
        {
            int Total = 0;
            vehicules = ServiceVehicule.VehiculesVendu();
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
    }
}