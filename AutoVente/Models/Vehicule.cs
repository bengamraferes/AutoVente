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
        public DateTime Date_mise_en_circulation { get; set; }

        [Required]
        [Column(TypeName="bigint")]
        public int Kilometrage { get; set; }

        [Required]
        public EtatVoiture Etat { get; set; }

        public Model Model { get; set; }

        [ForeignKey("Model")]
        public int Model_Id { get; set; }
        public Couleur Couleur { get; set; }

        public List<Photo> Photos { get; set; }

        public List<HystoriqueFrai> HystoriqueFrais { get; set; }

        public List<HystoriqueAchat> HystoriqueAchats { get; set; }

        public Vehicule()
        {
            Photos = new List<Photo>();
            HystoriqueFrais = new List<HystoriqueFrai>();
            HystoriqueAchats = new List<HystoriqueAchat>();
        }
    }
}



public enum EtatVoiture
{
    OCCASSION = 1,
    BON = 2,
    NEUF = 3
}
