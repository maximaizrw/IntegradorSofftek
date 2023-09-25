using System.ComponentModel.DataAnnotations;

namespace IntegradorSofftek.Models
{
    public class EstadoProyecto
    {
        
        public EstadoProyecto() { }
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
