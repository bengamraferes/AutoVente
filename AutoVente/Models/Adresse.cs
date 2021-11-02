using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("adresses")]
    public class Adresse
    {
        public int Id { get; set; }

        public string Ville { get; set; }
        [MaxLength(5)]
        [MinLength(5)]
        [Required(ErrorMessage ="Code postale non valide")]
        public char CodePostale { get; set; }
        [Required(ErrorMessage = "Adresse non valide")]
        public string Rue { get; set; }
        [Display(Name = "Complément d'adresse")]
        public string ComplementAdresse { get; set; }
        public List<Utilisateur> Utilisateurs{ get; set; }

        public Adresse()
        {
            Utilisateurs = new List<Utilisateur>();
        }
    }
}