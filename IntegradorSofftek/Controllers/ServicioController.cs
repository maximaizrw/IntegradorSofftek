using IntegradorSofftek.DTOs;
using IntegradorSofftek.Infraestructure;
using IntegradorSofftek.Services;
using IntegradorSofftek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todos los servicios.
        /// </summary>
        /// <returns>Una lista de todos los servicios.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();
            return ResponseFactory.CreateSuccessResponse(200, servicios);
        }

        /// <summary>
        /// Obtiene todos los servicios activos.
        /// </summary>
        /// <returns>Una lista de todos los servicios activos.</returns>
        [HttpGet]
        [Route("GetAllActivos")]
        public async Task<IActionResult> GetAllActivos()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAllActivos();
            return ResponseFactory.CreateSuccessResponse(200, servicios);
        }

        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        /// <param name="codServicio">El ID del servicio que se desea obtener.</param>
        /// <returns>El servicio correspondiente al ID proporcionado.</returns>
        [HttpGet("{codServicio}")]
        public async Task<IActionResult> GetById([FromRoute] int codServicio)
        {
            var servicio = await _unitOfWork.ServicioRepository.GetById(codServicio);
            if (servicio == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el servicio.");
            }
            return ResponseFactory.CreateSuccessResponse(200, servicio);
        }

        /// <summary>
        /// Inserta un nuevo servicio.
        /// </summary>
        /// <param name="dto">Los datos del servicio que se va a insertar.</param>
        /// <returns>Un mensaje de éxito indicando que el servicio se registró con éxito.</returns>
        [HttpPost]
        [Route("Insertar")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Insert(ServicioDTO dto)
        {
            var servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insertar(servicio);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con éxito.");
        }

        /// <summary>
        /// Modifica un servicio existente.
        /// </summary>
        /// <param name="codServicio">El ID del servicio que se va a modificar.</param>
        /// <param name="dto">Los datos actualizados del servicio.</param>
        /// <returns>Un mensaje de éxito indicando que el servicio se modificó con éxito.</returns>
        [HttpPut("{codServicio}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codServicio, ServicioDTO dto)
        {
            var servicio = new Servicio(dto, codServicio);
            var result = await _unitOfWork.ServicioRepository.Modificar(servicio);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el servicio.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Servicio modificado con éxito.");
        }

        /// <summary>
        /// Elimina un servicio por su ID.
        /// </summary>
        /// <param name="codServicio">El ID del servicio que se va a eliminar.</param>
        /// <returns>Un mensaje de éxito indicando que el servicio se eliminó con éxito.</returns>
        [HttpDelete("{codServicio}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codServicio)
        {
            var result = await _unitOfWork.ServicioRepository.Eliminar(codServicio);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el servicio.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Servicio eliminado con éxito.");
        }
    }
}
