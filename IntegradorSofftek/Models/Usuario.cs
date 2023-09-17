using IntegradorSofftek.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofftek.Models
{
    public class Usuario
    {
        public Usuario(RegistroDTO dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            //Tipo = dto.Tipo;
            Clave = dto.Clave;
        }

        public Usuario(RegistroDTO dto, int codUsuario)
        {
            CodUsuario = codUsuario;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            //Tipo = dto.Tipo;
            Clave = dto.Clave;
        }
        public Usuario() { }

        [Key]
        public int CodUsuario { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR (100)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int Dni { get; set; }
        [Required]
        public TipoUsuario Tipo { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR (100)")]
        public string Clave { get; set; }
    }

    public enum TipoUsuario
    {
        Administrador = 1,
        Consultor = 2
    }
}
