namespace IntegradorSofftek.DTOs
{
    public class ProyectoDTO
    {
        public string Nombre { get; set; }
        public string Direccion { get; set;}
        public EstadoProyecto Estado { get; set; }
    }

    public enum EstadoProyecto
    {
        Pendiente = 1,
        Confirmado = 2,
        Terminado = 3
    }
}
