using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    [Table("messages")]
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Contenu { get; set; }
        [Required]
        [MaxLength(100)]
        public string Titre { get; set; }

        [Required]
        public bool Ouvert { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        
        public Utilisateur Utilisateur { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }

    }
}