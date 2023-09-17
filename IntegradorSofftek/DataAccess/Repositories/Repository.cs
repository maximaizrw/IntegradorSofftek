using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<bool> Insertar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Modificar(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
