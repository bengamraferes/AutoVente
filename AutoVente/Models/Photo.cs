using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    public class Photo
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Photo non valide!")]
        [FileExtensions(Extensions = "png, jpg, jpeg")]
        [Display(Name = "Photo du Vehicule")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Au minimum une photo")]
        [Range(1,5)]
        public byte Numero { get; set; }
        public Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public int Immatriculation { get; set; }
    }
}