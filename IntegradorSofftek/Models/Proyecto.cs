using IntegradorSofftek.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofftek.Models
{
    public class Proyecto
    {
        public Proyecto() { }

        public Proyecto(ProyectoDTO dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = (EstadoProyecto)dto.Estado;
        }

        public Proyecto(ProyectoDTO dto, int codProyecto)
        {
            CodProyecto = codProyecto;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = (EstadoProyecto)dto.Estado;
        }

        [Key]
        public int CodProyecto { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR (100)")]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public EstadoProyecto Estado { get; set; }
    }

    public enum EstadoProyecto
    {
        Pendiente = 1,
        Confirmado = 2,
        Terminado = 3
    }
}
