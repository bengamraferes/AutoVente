﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoVente.Models
{
    [Table("images")]
    public class Photo: BaseEntity
    {
        [Required(ErrorMessage ="Photo non valide!")]
        [FileExtensions(Extensions = "png, jpg, jpeg")]
        [Display(Name = "Photo du Vehicule")]
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }
        [Required(ErrorMessage = "Au minimum une photo")]
        [Range(1,5)]
        public int Numero { get; set; }
        public Vehicule Vehicule { get; set; }
        [ForeignKey("Vehicule")]
        public string Immatriculation { get; private set; }
        public Photo(string url, int numero, Vehicule vehicule)
        {
            Url = url;
            Numero = numero;
            Vehicule = vehicule;
            Immatriculation = vehicule.Immatriculation;
        }
    }
}