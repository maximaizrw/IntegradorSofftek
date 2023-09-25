﻿using IntegradorSofftek.DTOs;
using IntegradorSofftek.Infraestructure;
using IntegradorSofftek.Models;
using IntegradorSofftek.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, usuarios);
        }

        [HttpGet("{codUsuario}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int codUsuario)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);

            if (usuario == null) return ResponseFactory.CreateErrorResponse(404, "No se encontro el usuario");

            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        [HttpPost]
        [Route("Registrar")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Registro(RegistroDTO dto)
        {
            if (await _unitOfWork.UsuarioRepository.UserExist(dto.Dni)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el dni: {dto.Dni}");
            var user = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insertar(user);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        [HttpPut("{codUsuario}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codUsuario, RegistroDTO dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Modificar(new Usuario(dto, codUsuario));

            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el usuario");

            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Usuario actualizado con exito!");
        }

        [HttpDelete("{codUsuario}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codUsuario)
        {
            var result = await _unitOfWork.UsuarioRepository.Eliminar(codUsuario);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el usuario");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Usuario eliminado con exito!");
        }
    }
}
