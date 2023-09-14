using IntegradorSofftek.DataAccess.Repositories;

namespace IntegradorSofftek.Services
{
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }

        Task<int> Complete();
    }
}
