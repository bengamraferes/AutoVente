using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{

    [Table("couleurs")]
    public class Couleur : BaseEntity
    {
        [Required]
        public string CodeCouleur { get; set; }
        public List<Model> Models { get; set; }
        public List<Vehicule> Vehicules { get; set; }

        public Couleur()
        {
            Vehicules = new List<Vehicule>();
        }
    }

}