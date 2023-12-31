﻿using IntegradorSofftek.DataAccess.Repositories.Interfaces;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IntegradorSofftek.DataAccess.Repositories
{
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<bool> Modificar(Rol modificarRol)
        {
            var Rol = await _context.Roles.FirstOrDefaultAsync(x => x.Id == modificarRol.Id);
            if (Rol == null)
                return false;

            Rol.Nombre = modificarRol.Nombre;
            Rol.Descripcion = modificarRol.Descripcion;
            Rol.Activo = modificarRol.Activo;


            _context.Roles.Update(Rol);
            return true;
        }

        public override async Task<bool> Eliminar(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
                return true; 
            }
            return false;
        }

    }
}
