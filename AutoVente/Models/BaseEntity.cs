using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoVente.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
    }
}