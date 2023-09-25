using IntegradorSofftek.DTOs;
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
    public class TrabajoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrabajoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todos los trabajos.
        /// </summary>
        /// <returns>Una lista de todos los trabajos.</returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerTrabajos()
        {
            var trabajos = await _unitOfWork.TrabajoRepository.ObtenerTrabajos();
            return ResponseFactory.CreateSuccessResponse(200, trabajos);
        }

        /// <summary>
        /// Obtiene un trabajo por su ID.
        /// </summary>
        /// <param name="codTrabajo">El ID del trabajo que se desea obtener.</param>
        /// <returns>El trabajo correspondiente al ID proporcionado.</returns>
        [HttpGet("{codTrabajo}")]
        public async Task<IActionResult> ObtenerTrabajo([FromRoute] int codTrabajo)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.ObtenerTrabajo(codTrabajo);
            return ResponseFactory.CreateSuccessResponse(200, trabajo);
        }

        /// <summary>
        /// Inserta un nuevo trabajo.
        /// </summary>
        /// <param name="dto">Los datos del trabajo que se va a insertar.</param>
        /// <returns>Un mensaje de éxito indicando que el trabajo se registró con éxito.</returns>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [Route("Insertar")]
        public async Task<IActionResult> Insertar(TrabajoDTO dto)
        {
            var trabajo = new Trabajo(dto);
            await _unitOfWork.TrabajoRepository.Insertar(trabajo);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con éxito!");
        }

        /// <summary>
        /// Modifica un trabajo existente.
        /// </summary>
        /// <param name="codTrabajo">El ID del trabajo que se va a modificar.</param>
        /// <param name="dto">Los datos actualizados del trabajo.</param>
        /// <returns>Un mensaje de éxito indicando que el trabajo se modificó con éxito.</returns>
        [HttpPut("{codTrabajo}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codTrabajo, TrabajoDTO dto)
        {
            var trabajo = new Trabajo(dto, codTrabajo);
            var result = await _unitOfWork.TrabajoRepository.Modificar(trabajo);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el trabajo.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Trabajo modificado con éxito!");
        }

        /// <summary>
        /// Elimina un trabajo por su ID.
        /// </summary>
        /// <param name="codTrabajo">El ID del trabajo que se va a eliminar.</param>
        /// <returns>Un mensaje de éxito indicando que el trabajo se eliminó con éxito.</returns>
        [HttpDelete("{codTrabajo}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codTrabajo)
        {
            var result = await _unitOfWork.TrabajoRepository.Eliminar(codTrabajo);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el trabajo.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Trabajo eliminado con éxito!");
        }
    }
}
