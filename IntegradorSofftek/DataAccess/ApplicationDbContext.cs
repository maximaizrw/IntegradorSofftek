using IntegradorSofftek.DataAccess.DatabaseSeeding;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Umsa.DataAccess.DatabaseSeeding;

namespace IntegradorSofftek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                new RolSeeder(),
                new ServicioSeeder(),
                new ProyectoSeeder()
            };

            foreach (var seeder in seeders)
            {
                seeder.SeedDatabse(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);

        }
    }
}
