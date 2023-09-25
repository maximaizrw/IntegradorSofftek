using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Proyecto>> GetAll()
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            listaProyectos = await _context.Proyectos.Include(x => x.EstadoProyecto).ToListAsync();
            return listaProyectos;
        }

        public async Task<Proyecto> GetById(int codProyecto)
        {
            Proyecto proyecto = new Proyecto();
            proyecto = await _context.Proyectos.Include(x => x.EstadoProyecto).FirstOrDefaultAsync(x => x.CodProyecto == codProyecto);
            return proyecto;
        }   

        // Obtener proyectos filtrando por estado
        public async Task<IEnumerable<Proyecto>> GetByEstado(int estadoId)
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            listaProyectos = await _context.Proyectos.Include(x => x.EstadoProyecto).Where(x => x.EstadoId == estadoId).ToListAsync();
            return listaProyectos;
        }

        public override async Task<bool> Modificar(Proyecto modificarProyecto)
        {
            var Proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.CodProyecto == modificarProyecto.CodProyecto);
            if (Proyecto == null)
                return false;

            Proyecto.Nombre = modificarProyecto.Nombre;
            Proyecto.Direccion = modificarProyecto.Direccion;
            Proyecto.EstadoId = modificarProyecto.EstadoId;

            _context.Proyectos.Update(Proyecto);
            return true;
        }

        public override async Task<bool> Eliminar(int codProyecto)
        {
            var Proyecto = await _context.Proyectos.Where(x => x.CodProyecto == codProyecto).FirstOrDefaultAsync();
            if (Proyecto != null)
                _context.Proyectos.Remove(Proyecto);

            return true;
        }

    }
}
