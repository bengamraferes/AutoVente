using System;
using System.ComponentModel.DataAnnotations;

namespace AutoVente.Models
{
    public class HystoriqueAchatVente : BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAchat { get; set; }
        public decimal Prix { get; set; }

        public bool Etat { get; set; }

    }
}