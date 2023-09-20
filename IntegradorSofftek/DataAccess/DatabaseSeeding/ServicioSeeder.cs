
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasData(
                new Servicio
                {
                    CodServicio = 1,
                    Descr = "Servicio 1",
                    Estado = true,
                    ValorHora = 10000,
                },
                new Servicio
                {
                    CodServicio = 2,
                    Descr = "Servicio 2",
                    Estado = true,
                    ValorHora = 20000,
                });
        }
    }
}
