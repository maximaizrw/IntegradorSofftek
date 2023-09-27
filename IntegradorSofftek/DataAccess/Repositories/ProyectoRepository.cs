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

        public async Task<bool> Eliminar(int codProyecto)
        {
            var proyecto = await _context.Proyectos.FindAsync(codProyecto);
            if (proyecto != null)
            {
                proyecto.Activo = false;
                _context.Proyectos.Update(proyecto);
                await _context.SaveChangesAsync();
                return true;
            }

            return false; 
        }

        public async Task<bool> ProyectoExist(int codProyecto)
        {
            return await _context.Proyectos.AnyAsync(x => x.CodProyecto == codProyecto);
        }

        public async Task<bool> ProyectoIsActive(int codProyecto)
        {
            return await _context.Proyectos.AnyAsync(x => x.CodProyecto == codProyecto && x.Activo == true);
        }

    }
}
