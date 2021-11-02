using System.ComponentModel.DataAnnotations;

namespace AutoVente.Models
{
    public class HystoriqueFrai : BaseEntity
    {
        [Required]
        public string Commentaire { get; set; }

        [Required]
        public decimal Cout { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string DateFrai { get; set; }
    }
}