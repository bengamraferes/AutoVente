using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("marques")]
    public class Marque : BaseEntityNom
    {
        [Required]
        public Origine Origine { get; set; }
        public List<Model> Models { get; set; }
        public Marque(string nom, Origine origine) : base(nom)
        {
            Models = new List<Model>();
            Origine = origine;
            Nom = nom;
        }

        public Marque()
        {
        }
    }

    public enum Origine
    {
        FRANCAISE = 1,
        ALLEMANDE = 2,
        ITALIENNE = 3,
        ESPAGNOLE = 4,
        AMERICAINE = 5,
        ANGLAISE = 6,
        JAMPONAISE = 7
    }
}

