using IntegradorSofftek.DataAccess.DatabaseSeeding;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder()
            };

            foreach (var seeder in seeders)
            {
                seeder.SeedDatabse(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);

        }
    }
}
