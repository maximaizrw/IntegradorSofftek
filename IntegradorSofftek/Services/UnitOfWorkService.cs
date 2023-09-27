using IntegradorSofftek.DataAccess;
using IntegradorSofftek.DataAccess.Repositories;

namespace IntegradorSofftek.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository UsuarioRepository { get; private set; }
        public RolRepository RolRepository { get; private set; }
        public ServicioRepository ServicioRepository { get; private set; }
        public ProyectoRepository ProyectoRepository { get; private set; }
        public TrabajoRepository TrabajoRepository { get; private set; }
        public EstadoProyectoRepository EstadoProyectoRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            RolRepository = new RolRepository(_context);
            ServicioRepository = new ServicioRepository(_context);
            ProyectoRepository = new ProyectoRepository(_context);
            TrabajoRepository = new TrabajoRepository(_context);
            EstadoProyectoRepository = new EstadoProyectoRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
