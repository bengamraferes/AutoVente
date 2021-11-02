using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    public class User : Utilisateur
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Le mot de passe doit contenir au moins une majuscule, une minuscule, un chiffre et un carathére spitiale et 8 caracthére ")]
        [RegularExpression("^ (?=.*[a - z])(?=.*[A - Z])(?=.*\\d)(?=.*[@$!% *? &])[A - Za - z\\d@$!% *? &]{8,}$")]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public Roles Role { get; set; }
    }
   public enum Roles
    {
        ADMNISTRATEUR =3 ,
        SECRETAIRE = 2,
        UTILISATEUR = 1

    }
}