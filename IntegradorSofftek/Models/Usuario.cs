using IntegradorSofftek.DTOs;
using IntegradorSofftek.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace IntegradorSofftek.Models
{
    public class Usuario
    {
        public Usuario(RegistroDTO dto)
        {
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            RolId = 2;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave);
        }

        public Usuario(RegistroDTO dto, int codUsuario)
        {
            CodUsuario = codUsuario;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            RolId = dto.RolId;
            Clave = PasswordEncryptHelper.EncryptPassword(dto.Clave);
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
        [Column(TypeName = "VARCHAR (250)")]
        public string Clave { get; set; }
        [Required]
        [Column("rol_id")]
        public int RolId { get; set; }
        public Rol? Rol { get; set; }
    }
}
