using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    public class Vehicule
    {
        [Key]
        public int Immatriculation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date de mise en circulation non valide")]
        public string DateMisEnCirculation { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public int Kilometrage { get; set; }

        [Required]
        public EtatVoiture Etat { get; set; }

        public bool TypeVente
        {
            get { return TypeVente; }
            set
            {
                if (value)
                {
                    this.Etat = EtatVoiture.NEUF;
                }
            }
        }
        public Model Model { get; set; }

        [ForeignKey("Model")]
        public int IdModel { get; set; }

        public Couleur Couleur { get; set; }
        [ForeignKey("Couleur")]
        public int IdCouleur { get; set; }
        public List<Photo> Photos { get; set; }
        // Au niveau du set condition pour avoir au moins une photo

        public List<HystoriqueFrai> HystoriqueFrais { get; set; }

        public List<HystoriqueAchatVente> HystoriqueAchats { get; set; }

        public List<Client> clients { get; set; }

        public Vehicule()
        {
            Photos = new List<Photo>();
            HystoriqueFrais = new List<HystoriqueFrai>();
            clients = new List<Client>();
            HystoriqueAchats = new List<HystoriqueAchatVente>();
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
}
  




