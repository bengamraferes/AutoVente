using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("adresses")]
    public class Adresse
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Ville { get; set; }
       
        [Required(ErrorMessage ="Code postale non valide")]
        [MaxLength(5)]
        [RegularExpression("^(?:[0-8]\\d|9[0-8])\\d{3}$")]
        public string CodePostale { get; set; }
        [Required(ErrorMessage = "Adresse non valide")]
        [MaxLength(255)]
        public string Rue { get; set; }
        [Display(Name = "Complément d'adresse")]
        [MaxLength(255)]
        public string ComplementAdresse { get; set; }
        public List<Utilisateur> Utilisateurs{ get; set; }

        public Adresse()
        {
            Utilisateurs = new List<Utilisateur>();
        }
    }
}