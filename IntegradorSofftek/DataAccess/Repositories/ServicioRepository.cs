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

        //Metodo eliminar, solo se debe cambiar el estado a false, no eliminar de la base de datos, verificar si esta activo antes de eliminar
        public override async Task<bool> Eliminar(int codServicio)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.CodServicio == codServicio);
            if (servicio == null)
                return false;

            servicio.Estado = false;

            _context.Servicios.Update(servicio);
            return true;
        }




        public async Task<bool> ServicioExist(int codServicio)
        {
            return await _context.Servicios.AnyAsync(x => x.CodServicio == codServicio);
        }

       //Metodo ServicioIsActive, verifica que el servicio este activo
        public async Task<bool> ServicioIsActive(int codServicio)
        {
            return await _context.Servicios.AnyAsync(x => x.CodServicio == codServicio && x.Estado == true);
        }
    }
}
