using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    
    public abstract class Utilisateur :BaseEntityNom
    {
        [Required(ErrorMessage ="Prenom non valide")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Email non valide")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(10)]
        [Required(ErrorMessage = "Numero Téléphone non valide")]
        [RegularExpression("^[+]?(?=(?:[^\\dx]*\\d){7})(?:\\(\\d+(?:\\.\\d+)?\\)|\\d+(?:\\.\\d+)?)(?:[ -]?(?:\\(\\d+(?:\\.\\d+)?\\)|\\d+(?:\\.\\d+)?))*(?:[ ]?(?:x|ext)\\.?[ ]?\\d{1,5})?$")]
        public string Telephone { get; set; }
    
        public Adresse Adresse { get; set; }

        [ForeignKey("Adresse")]
        public int IdAdress { get; set; }
        [NotMapped] //ignore ce champ pendant la migration
        public string FullName { get { return Nom + " " + Prenom; } }

        public List<Message> Messages { get; set; }

        public Utilisateur()
        {
            Messages = new List<Message>();
        }
    }
}