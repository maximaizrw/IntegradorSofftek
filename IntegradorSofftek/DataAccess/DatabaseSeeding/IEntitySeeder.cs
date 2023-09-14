using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabse(ModelBuilder modelBuilder);
    }
}
