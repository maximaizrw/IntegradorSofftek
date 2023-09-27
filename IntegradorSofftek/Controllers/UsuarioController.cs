using IntegradorSofftek.DTOs;
using IntegradorSofftek.Helpers;
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

        /// <summary>
        /// Obtiene todos los usuarios registrados de manera paginada.
        /// </summary>
        /// <returns>Una lista paginada de usuarios.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsuarios = PaginateHelper.Paginate<Usuario>((List<Usuario>)usuarios, pageToShow, url);
            return ResponseFactory.CreateSuccessResponse(200, paginateUsuarios);
        }

        /// <summary>
        /// Devuelve un usuario por su id
        /// </summary>
        /// <param name="codUsuario"></param>
        /// <returns>retorna un usuario</returns>
        [HttpGet("{codUsuario}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int codUsuario)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetById(codUsuario);

            if (usuario == null) return ResponseFactory.CreateErrorResponse(404, "No se encontro el usuario");

            return ResponseFactory.CreateSuccessResponse(200, usuario);
        }

        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>retorna un mensaje de exito o error</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroDTO dto)
        {
            if (await _unitOfWork.UsuarioRepository.UserExist(dto.Dni)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el dni: {dto.Dni}");
            var user = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insertar(user);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        /// <summary>
        /// Modificar un usuario
        /// </summary>
        /// <param name="codUsuario"></param>
        /// <param name="dto"></param>
        /// <returns>retorna un mensaje de exito o error</returns>
        [Authorize(Policy = "Administrador")]
        [HttpPut("{codUsuario}")]
        public async Task<IActionResult> Modificar([FromRoute] int codUsuario, RegistroDTO dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Modificar(new Usuario(dto, codUsuario));

            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el usuario");

            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Usuario actualizado con exito!");
        }

        /// <summary>
        /// Eliminar un usuario
        /// </summary>
        /// <param name="codUsuario"></param>
        /// <returns>retorna un mensaje de exito o error</returns>
        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codUsuario}")]
        public async Task<IActionResult> Eliminar([FromRoute] int codUsuario)
        {
            var result = await _unitOfWork.UsuarioRepository.Eliminar(codUsuario);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el usuario");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Usuario eliminado con exito!");
        }
    }
}
