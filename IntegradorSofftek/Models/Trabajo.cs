using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntegradorSofftek.Models
{
    public class Trabajo
    {
        [Key]
        public int CodTrabajo { get; set; }
        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Required]
        [ForeignKey("CodProyecto")]
        public Proyecto CodProyecto { get; set; }
        [Required]
        [ForeignKey("CodServicio")]
        public Servicio CodServicio { get; set; }
        [Required]
        public int CantHoras { get; set; }
        [Required]
        public decimal ValorHora { get; set; }
        [Required]
        public decimal Costo => CantHoras * ValorHora;
    }
}
