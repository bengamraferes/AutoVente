using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoVente.Models
{
    public class Marque : BaseEntity
    {
        [Required]
        public Pays Pays { get; set; }

        public List<Model> Models { get; set; }

        public Marque(List<Model> models)
        {
            Models = models;
        }

        public int IdMarque { get; set; }
    }
}

public enum Pays
{
    FRANCAISE = 1,
    ALLEMANDE = 2,
    ITALIENNE = 3,
    ESPAGNOLE = 4,
    AMERICAINE = 5,
    ANGLAISE = 6,
    JAMPONAISE = 7
}