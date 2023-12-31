﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IntegradorSofftek.DTOs;

namespace IntegradorSofftek.Models
{

    public class Trabajo
    {
        public Trabajo() { }

        public Trabajo(TrabajoDTO dto)
        {
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
        }

        public Trabajo(TrabajoDTO dto, int codTrabajo)
        {
            CodTrabajo = codTrabajo;
            Fecha = dto.Fecha;
            CodProyecto = dto.CodProyecto;
            CodServicio = dto.CodServicio;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
        }

        [Key]
        public int CodTrabajo { get; set; }
        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        [ForeignKey("CodProyecto")]
        public Proyecto? Proyecto { get; set; }
        [Required]
        public int CodServicio { get; set; }
        [ForeignKey("CodServicio")]
        public Servicio? Servicio { get; set; }
        [Required]
        public int CantHoras { get; set; }
        [Required]
        public decimal ValorHora { get; set; }
        [Required]
        public decimal Costo => CantHoras * ValorHora;
    }
}
