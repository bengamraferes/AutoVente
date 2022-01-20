using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("hystoriqueAchatsVentes")]
    public class HystoriqueAchatVente : BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAchatVente { get; set; }
        [Required]
        public int Prix { get; set; }
        [Required]
        public AchatVente Etat { get; set; }
        public Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public string Immatriculation { get; private set; }

        public HystoriqueAchatVente()
        {
           
        }

        public HystoriqueAchatVente(int prix, AchatVente etat, DateTime dateAchatVente , Vehicule vehicule)
        {
            Prix = prix;
            Etat = etat;
            Vehicule = vehicule;
            DateAchatVente = dateAchatVente;
            Immatriculation = vehicule.Immatriculation;
        }
        public enum AchatVente
        {
            VENTE = 1,
            ACHAT = 2
        }
    }
}