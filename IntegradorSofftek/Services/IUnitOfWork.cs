using IntegradorSofftek.DataAccess.Repositories;

namespace IntegradorSofftek.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }

        Task<int> Complete();
    }
}
