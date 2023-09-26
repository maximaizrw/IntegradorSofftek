using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.DTOs;
using IntegradorSofftek.Helpers;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Modificar(Usuario modificarUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.CodUsuario == modificarUsuario.CodUsuario);
            if (usuario == null)
                return false;

            usuario.Nombre = modificarUsuario.Nombre;
            usuario.Dni = modificarUsuario.Dni;
            usuario.Clave = modificarUsuario.Clave;

            _context.Usuarios.Update(usuario);
            return true;
        }

        public override async Task<bool> Eliminar(int codUsuario)
        {
            var usuario = await _context.Usuarios.Where(x => x.CodUsuario == codUsuario).FirstOrDefaultAsync();
            if (usuario != null)
                _context.Usuarios.Remove(usuario);


            return true;
        }

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDTO dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Dni == dto.Dni && x.Clave == PasswordEncryptHelper.EncryptPassword(dto.Clave, dto.Dni));
        }

        public async Task<bool> UserExist(int dni)
        {
            return await _context.Usuarios.AnyAsync(x => x.Dni == dni);
        }

    }
}
