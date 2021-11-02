using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("models")]
    public class Model : BaseEntity
    {
        [Required(ErrorMessage = "Numéro obligatoire")]
        [MaxLength(50)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Type de carburent obligatoire")]
        public Carburent Carburent { get; set; }

        [Required(ErrorMessage = "Taux d'émission obligatoire")]
        [Display(Name ="Emission CO2")]
        public decimal EmissionCo2 { get; set; }

        [Required (ErrorMessage = "Date obligatoire")]
        [DataType(DataType.Date)]
        public string Annee { get; set; }

        [Required(ErrorMessage = "Puissance du moteur obligatoire")]
        [Display(Name = "Puissance moteur")]
        public byte PuissanceReel { get; set; }

        [Required(ErrorMessage = "Nombre de places obligatoire")]
        [Display(Name = "Nombres de places")]
        [MaxLength(9)]
        public byte NbPlaces { get; set; }

        [Required(ErrorMessage = "Type obligatoire")]
        public Type Type { get; set; }

        [Required(ErrorMessage = "Prix obligatoire")]
        public decimal Prix { get; set; }

        [Required(ErrorMessage = "Type de boite de vitesse obligatoire")]
        public BoiteVitesse BoiteDeVitesse { get; set; }

        public List<Vehicule> Vehicules { get; set; }
       
        public Marque Marque { get; set; }
        [ForeignKey("Marque")]
        public int MarqueId { get; set; }

        public Model()
        {
            Vehicules = new List<Vehicule>();
        }
    }
    public enum Carburent
    {
        ESSENCE = 1,
        GASOLE = 2,
        ELECTRIQUE = 3,
        HYBRIDERECHARGEABLE = 4,
        HYBRIDENONRECHARGEABLE = 5
    }

    public enum Type
    {
        BREAK = 1,
        CITADINE = 2,
        ROUTIERE = 3,
        SPROTIVE = 4,
        MONOSPACE = 5,
        SUV = 6,
        LUDOSPACE = 7,
        BERLINE = 8
    }


    public enum BoiteVitesse
    {
        AUTO = 1,
        MANUEL = 2
    }
}

