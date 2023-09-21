namespace IntegradorSofftek.DTOs
{
    public class TrabajoDTO
    {
        public DateTime Fecha { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo => CantHoras * ValorHora;
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
    }
}
