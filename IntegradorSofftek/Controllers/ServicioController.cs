using IntegradorSofftek.DTOs;
using IntegradorSofftek.Infraestructure;
using IntegradorSofftek.Services;
using IntegradorSofftek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IntegradorSofftek.Helpers;
using System.Data;

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
        /// Obtiene todos los servicios con paginado.
        /// </summary>
        /// <returns>Una lista de todos los servicios.</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServicios = PaginateHelper.Paginate(servicios, pageToShow, url);
            return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
        }

        /// <summary>
        /// Obtiene todos los servicios activos.
        /// </summary>
        /// <returns>Una lista de todos los servicios activos.</returns>
        [Authorize]
        [HttpGet("Activos")]
        public async Task<IActionResult> GetAllActivos()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAllActivos();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateServicios = PaginateHelper.Paginate<Servicio>((List<Servicio>)servicios, pageToShow, url);
            return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
        }


        /// <summary>
        /// Obtiene un servicio por su ID.
        /// </summary>
        /// <param name="codServicio">El ID del servicio que se desea obtener.</param>
        /// <returns>El servicio correspondiente al ID proporcionado.</returns>
        [Authorize]
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
        [Authorize(Policy = "Administrador")]
        [HttpPost]
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
        [Authorize(Policy = "Administrador")]
        [HttpPut("{codServicio}")]
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
        [Authorize(Policy = "Administrador")]
        [HttpDelete("{codServicio}")]
        public async Task<IActionResult> Eliminar([FromRoute] int codServicio)
        {
            if (!await _unitOfWork.ServicioRepository.ServicioIsActive(codServicio))
            {
                return ResponseFactory.CreateErrorResponse(403, "El servicio ya se encuentra inactivo.");
            }
            var result = await _unitOfWork.ServicioRepository.Eliminar(codServicio);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el servicio.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Servicio dado de baja con éxito.");
        }
    }
}
