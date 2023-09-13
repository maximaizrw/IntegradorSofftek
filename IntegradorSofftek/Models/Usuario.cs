using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofftek.Models
{
    public class Usuario
    {
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
