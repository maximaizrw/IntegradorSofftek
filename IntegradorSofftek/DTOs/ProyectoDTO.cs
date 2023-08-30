using IntegradorSofftek.Models;

namespace IntegradorSofftek.DTOs
{
    public class ProyectoDTO
    {
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public EstadoProyecto Estado { get; set; }
    }

    public enum EstadoProyecto
    {
        Pendiente = 1,
        Confirmado = 2,
        Terminado = 3
    }
}
