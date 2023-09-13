﻿using IntegradorSofftek.Models;

namespace IntegradorSofftek.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public TipoUsuario Tipo { get; set; }
    }

    public enum TipoUsuario
    {
        Administrador = 1,
        Consultor = 2
    }
}
