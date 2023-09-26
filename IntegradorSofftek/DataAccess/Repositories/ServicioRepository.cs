using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {
        public ServicioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Servicio>> GetAllActivos()
        {
            return await _context.Servicios.Where(x => x.Estado == true).ToListAsync();
        }

        public override async Task<bool> Modificar(Servicio modificarServicio)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.CodServicio == modificarServicio.CodServicio);
            if (servicio == null)
                return false;

            servicio.Descr = modificarServicio.Descr;
            servicio.Estado = modificarServicio.Estado;
            servicio.ValorHora = modificarServicio.ValorHora;

            _context.Servicios.Update(servicio);
            return true;
        }

        public override async Task<bool> Eliminar(int codServicio)
        {
            var servicio = await _context.Servicios.FindAsync(codServicio);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                await _context.SaveChangesAsync();
                return true; 
            }

            return false; 
        }


        public async Task<bool> ServicioExist(int codServicio)
        {
            return await _context.Servicios.AnyAsync(x => x.CodServicio == codServicio);
        }
    }
}
