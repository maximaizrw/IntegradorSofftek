using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofftek.Models
{
    public class Servicio
    {
        [Key]
        public int CodServicio { get; set; }
        [Required]
        public string Descr { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool Estado { get; set; }
        [Required]
        public decimal ValorHora { get; set; }
    }
}
