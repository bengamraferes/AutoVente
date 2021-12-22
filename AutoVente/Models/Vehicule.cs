using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    public class Vehicule : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get => base.Id; set => base.Id = value; }
        [Key]
        public string Immatriculation { get; set; }
        [Required(ErrorMessage = "Date de mise en circulation non valide")]
        [Display(Name = "Date mise en circulation")]
        [DataType(DataType.Date)]
        public string DateMisEnCirculation { get; set; }
        [Required(ErrorMessage = "Kilometrage obligatoire")]
        [Column(TypeName = "bigint")]
        public int Kilometrage { get; set; }

        [Required(ErrorMessage = "Prix obligatoire")]
        public int Prix { get; set; }
        [Required(ErrorMessage = "Etat du vehicule obligatoire")]
        public EtatVoiture Etat { get; set; }
        public Model Model { get; private set; }
        [ForeignKey("Model")]
        public int IdModel { get; private set; }
        public Couleur Couleur { get; set; }
        [ForeignKey("Couleur")]
        public int IdCouleur { get; set; }
        public List<Photo> Photos { get; set; }
        // Au niveau du set condition pour avoir au moins une photo
        public Vendu Vendu { get; set; }
        public List<HystoriqueFrai> HystoriqueFrais { get; set; }
        public List<HystoriqueAchatVente> HystoriqueAchats { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }
        public Vehicule(string immatriculation, string dateMisEnCirculation, int kilometrage, EtatVoiture etat, int idModel, int idCouleur/*, List<Photo> photos*/)
        {
            HystoriqueAchats = new List<HystoriqueAchatVente>();
            HystoriqueFrais = new List<HystoriqueFrai>();
            Utilisateurs = new List<Utilisateur>();
            Immatriculation = immatriculation;
            DateMisEnCirculation = dateMisEnCirculation;
            Kilometrage = kilometrage;
            Etat = etat;
            //Photos = photos;
            IdModel = idModel;
            IdCouleur = idCouleur;
            Vendu = Vendu.NON_VENDU;
        }

        public Vehicule()
        {
        }
    }
    public enum EtatVoiture
    {
        NEUF = 1,
        PARFAIT = 2,
        TRES_BON = 3,
        BON = 4,
        MOYEN = 5,
        MAUVAIS = 6,
        TRES_MOVAIS = 7
    }
    public enum Vendu
    {
        NON_VENDU = 1,
        VENDU = 2
    }
}





