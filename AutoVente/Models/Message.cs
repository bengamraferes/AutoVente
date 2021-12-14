using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    [Table("messages")]
    public class Message : BaseEntity
    {

        [Required]
        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        public string Contenu { get; set; }
        [Required]
        [MaxLength(100)]
        public string Titre { get; set; }
        [Required]
        public EtatsMessage EtatMessage { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; private set; }

        public Message(string contenu, string titre, Utilisateur utilisateur)
        {
            Contenu = contenu;
            Titre = titre;
            Date = DateTime.Now;
            Utilisateur = utilisateur;
            IdUtilisateur = utilisateur.Id;
        }

        public Message()
        {
        }
    }

    public enum EtatsMessage
    {
        OUVERT,
        FERME
    }
}