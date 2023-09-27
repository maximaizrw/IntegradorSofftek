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
            Activo = true;
            EstadoId = dto.EstadoId;
        }

        public Proyecto(ProyectoDTO dto, int codProyecto)
        {
            CodProyecto = codProyecto;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            EstadoId = dto.EstadoId;
        }

        [Key]
        public int CodProyecto { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR (100)")]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public EstadoProyecto? EstadoProyecto { get; set; }

    }


}
