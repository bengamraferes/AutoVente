using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    [Table("utilisateur")]
    public class Utilisateur :BaseEntityNom
    {
        [Required(ErrorMessage ="Prenom non valide")]
        public string Prenom { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe doit contenir au moins une majuscule, une minuscule, un chiffre et un carathére special et 8 caractères ")]
        //[RegularExpression("^ (?=.*[a - z])(?=.*[A - Z])(?=.*\\d)(?=.*[@$!% *? &])[A - Za - z\\d@$!% *? &]{8,}$")]
        public string Password { get; set; }
        [MaxLength(255)]
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name ="Confirmer le mot de passe")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email non valide")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(10)]
        [Required(ErrorMessage = "Numero Téléphone non valide")]
        //[RegularExpression("^[+]?(?=(?:[^\\dx]*\\d){7})(?:\\(\\d+(?:\\.\\d+)?\\)|\\d+(?:\\.\\d+)?)(?:[ -]?(?:\\(\\d+(?:\\.\\d+)?\\)|\\d+(?:\\.\\d+)?))*(?:[ ]?(?:x|ext)\\.?[ ]?\\d{1,5})?$")]
        public string Telephone { get; set; }
        public Adresse Adresse { get; set; }
        [ForeignKey("Adresse")]
        public int IdAdress { get; private set; }
        [NotMapped] //ignore ce champ pendant la migration
        public string FullName { get { return Nom + " " + Prenom; } }
        private List<Vehicule> _favories;
        public List<Vehicule> Favories
        {
            get
            {
                if (this.Role == Roles.CLIENT)
                {
                    return _favories;
                }
                else
                {
                    return null;
                }
            }
            set {
                if (this.Role == Roles.CLIENT)
                {
                    _favories = value;
                    
                }
            }
        }
        public Roles Role { get; set; }
        private List<Message> _messages;

        public List<Message> Messages
        {
            get
            {
                if (this.Role == Roles.SECRETAIRE)
                {
                       return _messages;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (this.Role == Roles.SECRETAIRE)
                {
                    _messages = value;

                }
            }
        }

        public Utilisateur()
        {
        }

        public Utilisateur(string prenom, string password, string email, Adresse adresse, Roles role, string nom) : base(nom) 
        {
            Prenom = prenom;
            Password = password;
            Email = email;
            Adresse = adresse;
            Role = role;
            IdAdress = Adresse.Id;
            if (role == Roles.SECRETAIRE)
            {
                _messages = new List<Message>();
            }
            if (role == Roles.CLIENT)
            {
                _favories = new List<Vehicule>();
            }
        }
    }
    public enum Roles
    {
        ADMINISTRATEUR = 3,
        SECRETAIRE = 2,
        UTILISATEUR = 1,
        CLIENT = 0
    }
}