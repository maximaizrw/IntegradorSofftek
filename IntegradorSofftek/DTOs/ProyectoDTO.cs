using IntegradorSofftek.Models;

namespace IntegradorSofftek.DTOs
{
    public class ProyectoDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set;}
        public EstadoProyecto Estado { get; set; }
    }
}
