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

        public override async Task<bool> Modificar(Servicio modificarServicio)
        {
            var Servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.CodServicio == modificarServicio.CodServicio);
            if (Servicio == null)
                return false;

            Servicio.Descr = modificarServicio.Descr;
            Servicio.Estado = modificarServicio.Estado;
            Servicio.ValorHora = modificarServicio.ValorHora;

            _context.Servicios.Update(Servicio);
            return true;
        }

        public override async Task<bool> Eliminar(int codServicio)
        {
            var Servicio = await _context.Servicios.Where(x => x.CodServicio == codServicio).FirstOrDefaultAsync();
            if (Servicio != null)
                _context.Servicios.Remove(Servicio);

            return true;
        }
    }
}
