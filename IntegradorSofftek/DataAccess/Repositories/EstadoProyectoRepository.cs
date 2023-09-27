using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class EstadoProyectoRepository : Repository<EstadoProyecto>, IEstadoProyectoRepository
    {
        public EstadoProyectoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<bool> EstadoExist (int estadoId)
        {
            return await _context.EstadosProyecto.AnyAsync(x => x.Id == estadoId);
            
        }
    }
}
