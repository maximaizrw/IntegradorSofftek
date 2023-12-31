﻿using IntegradorSofftek.Helpers;
using IntegradorSofftek.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofftek.DataAccess.DatabaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDatabse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    CodUsuario = 1,
                    Nombre = "admin",
                    Dni = 1234,
                    Clave = PasswordEncryptHelper.EncryptPassword("1234",1234),
                    RolId = 1
                },
                new Usuario
                {
                    CodUsuario = 2,
                    Nombre = "consultor",
                    Dni = 12345,
                    Clave = PasswordEncryptHelper.EncryptPassword("12345",12345),
                    RolId = 2
                }
                );

        }
    }
}
