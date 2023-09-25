using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public class EstadoProyectoSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoProyecto>().HasData(
                new EstadoProyecto
                {
                    Id = 1,
                    Descripcion = "Pendiente"
                },
                new EstadoProyecto
                {
                    Id = 2,
                    Descripcion = "Confirmado"
                },
                new EstadoProyecto
                {
                    Id = 3,
                    Descripcion = "Terminado"
                });
        }
    }


}
