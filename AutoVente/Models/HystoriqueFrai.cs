using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    public class HystoriqueFrai : BaseEntity
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(1000)]
        public string Commentaire { get; set; }

        [Required]
        public decimal Cout { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFrai { get; set; }
        [Required]
        public Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public int Immatriculation { get; set; }
    }
}