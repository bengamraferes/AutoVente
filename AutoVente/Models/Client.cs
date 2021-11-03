using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    [Table("clients")]
    public class Client : Utilisateur
    {
        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe doit contenir au moins une majuscule, une minuscule, un chiffre et un carathére spitiale et 8 caracthére ")]
        [RegularExpression("^ (?=.*[a - z])(?=.*[A - Z])(?=.*\\d)(?=.*[@$!% *? &])[A - Za - z\\d@$!% *? &]{8,}$")]
        public string Password { get; set; }
        [MaxLength(255)]
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public List<Vehicule> Favories { get; set; }

        public Client()
        {
            Favories =new List<Vehicule>();
        }
    }
}