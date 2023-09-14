using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodUsuario = 1,
                    Nombre = "Administrador",
                    Dni = 12345678,
                    Tipo = TipoUsuario.Administrador,
                    Clave = "123456"
                }
                );

        }
    }
}
