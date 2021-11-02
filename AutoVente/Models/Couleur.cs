using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoVente.Models
{
    public class Couleur : BaseEntity
    {
        [Required]
        public string CodeCouleur { get; set; }
        public List<Model> Models { get; set; }
        public List<Vehicule> Vehicules { get; set; }
    }
}