using IntegradorSofftek.DTOs;
using IntegradorSofftek.Infraestructure;
using IntegradorSofftek.Models;
using IntegradorSofftek.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todos los roles.
        /// </summary>
        /// <returns>Una lista de todos los roles.</returns>
        [HttpGet]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _unitOfWork.RolRepository.GetAll();
            return ResponseFactory.CreateSuccessResponse(200, roles);
        }

        /// <summary>
        /// Inserta un nuevo rol.
        /// </summary>
        /// <param name="dto">Los datos del rol que se va a insertar.</param>
        /// <returns>Un mensaje de éxito indicando que el rol se registró con éxito.</returns>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [Route("Insertar")]
        public async Task<IActionResult> Insert(RolDTO dto)
        {
            var rol = new Rol(dto);
            await _unitOfWork.RolRepository.Insertar(rol);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Rol registrado con éxito.");
        }

        /// <summary>
        /// Modifica un rol existente.
        /// </summary>
        /// <param name="id">El ID del rol que se va a modificar.</param>
        /// <param name="dto">Los datos actualizados del rol.</param>
        /// <returns>Un mensaje de éxito indicando que el rol se modificó con éxito.</returns>
        [HttpPut("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int id, RolDTO dto)
        {
            var rol = new Rol(dto, id);
            var result = await _unitOfWork.RolRepository.Modificar(rol);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el rol.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Rol modificado con éxito.");
        }

        /// <summary>
        /// Elimina un rol por su ID.
        /// </summary>
        /// <param name="id">El ID del rol que se va a eliminar.</param>
        /// <returns>Un mensaje de éxito indicando que el rol se eliminó con éxito.</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            var result = await _unitOfWork.RolRepository.Eliminar(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el rol.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Rol eliminado con éxito.");
        }
    }
}
