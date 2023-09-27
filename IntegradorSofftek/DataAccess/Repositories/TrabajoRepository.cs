using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
    {
        public TrabajoRepository(ApplicationDbContext context) : base(context)
        {
        }

        //Metodo para obtener trabajos con las tablas servicio y proyecto asociada
        public async Task<IEnumerable<Trabajo>> GetAll()
        {
            List<Trabajo> listaTrabajos = new List<Trabajo>();
            listaTrabajos = await _context.Trabajos.Include(x => x.Servicio).Include(x => x.Proyecto).ToListAsync();
            return listaTrabajos;
        }

        //Metodo para obtener un trabajo con las tablas servicio y proyecto asociada
        public async Task<Trabajo> ObtenerTrabajo(int codTrabajo)
        {
            Trabajo trabajo = new Trabajo();
            trabajo = await _context.Trabajos.Include(x => x.Servicio).Include(x => x.Proyecto).FirstOrDefaultAsync(x => x.CodTrabajo == codTrabajo);
            return trabajo;
        }

        public async Task<bool> TrabajoExist(int codTrabajo)
        {
            return await _context.Trabajos.AnyAsync(x => x.CodTrabajo == codTrabajo);
        }

        public override async Task<bool> Modificar(Trabajo modificarTrabajo)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.CodTrabajo == modificarTrabajo.CodTrabajo);
            if (trabajo == null)
                return false;

            trabajo.Fecha = modificarTrabajo.Fecha;
            trabajo.CodProyecto = modificarTrabajo.CodProyecto;
            trabajo.CodServicio = modificarTrabajo.CodServicio;
            trabajo.CantHoras = modificarTrabajo.CantHoras;
            trabajo.ValorHora = modificarTrabajo.ValorHora;

            _context.Trabajos.Update(trabajo);
            return true;

        }

        public override async Task<bool> Eliminar(int codTrabajo)
        {
            var trabajo = await _context.Trabajos.Where(x => x.CodTrabajo == codTrabajo).FirstOrDefaultAsync();
            if (trabajo != null)
            {
                _context.Trabajos.Remove(trabajo);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }


}
