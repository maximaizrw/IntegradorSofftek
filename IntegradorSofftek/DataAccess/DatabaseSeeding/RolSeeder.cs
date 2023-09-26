
using IntegradorSofftek.DataAccess.DatabaseSeeding;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;


namespace Umsa.DataAccess.DatabaseSeeding
{
    public class RolSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    Id = 1,
                    Nombre = "Administrador",
                    Descripcion = "Administrador",
                    Activo = true,
                },
                new Rol
                {
                    Id = 2,
                    Nombre = "Consultor",
                    Descripcion = "Consultor",
                    Activo = true,
                });
        }
    }
}