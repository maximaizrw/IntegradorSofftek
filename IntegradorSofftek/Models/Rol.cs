using IntegradorSofftek.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofftek.Models
{
    public class Rol
    {
        public Rol() { }

        public Rol(RolDTO dto)
        {
            Nombre = dto.Nombre;
            Descripcion = dto.Descripcion;
            Activo = dto.Activo;
        }
        public Rol(RolDTO dto, int id)
        {
            Id = id;
            Nombre = dto.Nombre;
            Descripcion = dto.Descripcion;
            Activo = dto.Activo;
        }

        

        [Column("rol_id")]
        public int Id { get; set; }
        [Column("rol_nombre")]
        public string Nombre { get; set; }
        [Column("rol_descripcion")]
        public string Descripcion { get; set; }
        [Column("rol_activo")]
        public bool Activo { get; set; }
    }
}
