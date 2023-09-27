using IntegradorSofftek.Models;

namespace IntegradorSofftek.DTOs
{
    public class ProyectoDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set;}
        public bool Activo { get; set; }
        public int EstadoId { get; set; }
    }
}
