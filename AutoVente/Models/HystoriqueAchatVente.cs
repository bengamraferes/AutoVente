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
        public decimal Prix { get; set; }

        public bool Etat { get; set; }

        public Vehicule Vehicules { get; set; }
        [ForeignKey("Vehicule")]
        public string Immatriculation { get; set; }
    }
}