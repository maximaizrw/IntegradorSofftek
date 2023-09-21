using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>().HasData(
                new Trabajo
                {
                    CodTrabajo = 1,
                    Fecha = DateTime.Now,
                    CodProyecto = 1,
                    CodServicio = 1,
                    CantHoras = 10,
                    ValorHora = 10000,
                },
                new Trabajo
                {
                    CodTrabajo = 2,
                    Fecha = DateTime.Now,
                    CodProyecto = 2,
                    CodServicio = 2,
                    CantHoras = 20,
                    ValorHora = 20000,
                });
        }
    }
}
