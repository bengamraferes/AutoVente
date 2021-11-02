using System.ComponentModel.DataAnnotations;

namespace AutoVente.Models
{
    public class Couleur : BaseEntity
    {
        [Required]
        public string CodeCouleur { get; set; }
    }
}