using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.DTOs;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDTO dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Dni == dto.Dni && x.Clave == dto.Clave);
        }



    }
}
