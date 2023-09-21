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

        public override async Task<bool> Modificar(Proyecto modificarProyecto)
        {
            var Proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.CodProyecto == modificarProyecto.CodProyecto);
            if (Proyecto == null)
                return false;

            Proyecto.Nombre = modificarProyecto.Nombre;
            Proyecto.Direccion = modificarProyecto.Direccion;
            Proyecto.Estado = modificarProyecto.Estado;

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
