using System.ComponentModel.DataAnnotations.Schema;

namespace IntegradorSofftek.Models
{
    public class Usuario
    {
        [Column("codUsuario")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Clave { get; set; }
    }

    public enum TipoUsuario
    {
        Administrador = 1,
        Consultor = 2
    }
}
