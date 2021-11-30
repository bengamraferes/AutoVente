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
        public DateTime DateAchat { get; set; }
        [Required]
        public int Prix { get; set; }
        [Required]
        public AchatVente Etat { get; set; }
        public Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public string Immatriculation { get; private set; }
        public HystoriqueAchatVente(int prix, AchatVente etat, Vehicule vehicule)
        {
            Prix = prix;
            Etat = etat;
            Vehicule = vehicule;
            Immatriculation = vehicule.Immatriculation;
        }
        public enum AchatVente
        {
            VENTE = 1,
            ACHAT = 2
        }
    }
}