using IntegradorSofftek.DataAccess.Repositories;

namespace IntegradorSofftek.Services
{
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
        public RolRepository RolRepository { get; }
        public ServicioRepository ServicioRepository { get; }

        Task<int> Complete();
    }
}
