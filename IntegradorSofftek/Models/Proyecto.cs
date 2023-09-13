using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofftek.Models
{
    public class Proyecto
    {
        [Key]
        public int CodProyecto { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR (100)")]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public EstadoProyecto Estado { get; set; }
    }

    public enum EstadoProyecto
    {
        Pendiente = 1,
        Confirmado = 2,
        Terminado = 3
    }
}
