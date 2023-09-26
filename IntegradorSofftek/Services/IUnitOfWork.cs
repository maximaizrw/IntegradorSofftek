using IntegradorSofftek.DataAccess.Repositories;

namespace IntegradorSofftek.Services
{
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
        public RolRepository RolRepository { get; }
        public ServicioRepository ServicioRepository { get; }
        public ProyectoRepository ProyectoRepository { get; }
        public TrabajoRepository TrabajoRepository { get; }
        public EstadoProyectoRepository EstadoProyectoRepository { get; }

        Task<int> Complete();
    }
}
