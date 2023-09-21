﻿using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    CodProyecto = 1,
                    Nombre = "Proyecto 1",
                    Direccion = "Direccion 1",
                    Estado = EstadoProyecto.Pendiente,
                },
                new Proyecto
                {
                    CodProyecto = 2,
                    Nombre = "Proyecto 2",
                    Direccion = "Direccion 2",
                    Estado = EstadoProyecto.Terminado,
                });
        }
    }
}
