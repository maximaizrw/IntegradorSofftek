using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IntegradorSofftek.DTOs;

namespace IntegradorSofftek.Models
{
    public class Servicio
    {
        public Servicio() { }

        public Servicio(ServicioDTO dto)
        {
            Descr = dto.Descr;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;
        }
        public Servicio(ServicioDTO dto, int codServicio)
        {
            CodServicio = codServicio;
            Descr = dto.Descr;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;
        }

        [Key]
        public int CodServicio { get; set; }
        [Required]
        public string Descr { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool Estado { get; set; }
        [Required]
        public decimal ValorHora { get; set; }

        
    }
}
