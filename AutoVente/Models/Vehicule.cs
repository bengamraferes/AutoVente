using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    public class Vehicule
    {
        public int Id_Vehicule { get; set; }
        public DateTime Date_mise_en_service { get; set; }
        public int Kilometrage { get; set; }

        public EtatVoiture Etat { get; set; }
    }
}
public enum EtatVoiture
{
    OCCASSION = 1,
    BON = 2,
    NEUF = 3
}
