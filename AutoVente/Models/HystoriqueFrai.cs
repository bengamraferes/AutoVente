using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("hystoriqueFrais")]
    public class HystoriqueFrai : BaseEntity
    {
        [Required(ErrorMessage ="Titre obligatoire")]
        [DataType(DataType.Text)]
        [MaxLength(200)]
        public string Titre { get; set; }
        [Required(ErrorMessage = "Commentaire obligatoire")]
        [DataType(DataType.Text)]
        [MaxLength(1000)]
        public string Commentaire { get; set; }
        [Required(ErrorMessage = "Cout obligatoire")]
        public decimal Cout { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateFrai { get; set; }
        public Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public string Immatriculation { get; private set; }
        public HystoriqueFrai(string titre, string commentaire, decimal cout, Vehicule vehicule)
        {
            Titre = titre;
            Commentaire = commentaire;
            Cout = cout;
            Vehicule = vehicule;
            DateFrai = DateTime.Now;
            Immatriculation = vehicule.Immatriculation;
        }
    }
}