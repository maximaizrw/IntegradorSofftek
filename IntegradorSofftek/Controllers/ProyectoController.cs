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
    public class ProyectoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProyectoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todos los proyectos.
        /// </summary>
        /// <returns>Una lista de todos los proyectos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();
            return ResponseFactory.CreateSuccessResponse(200, proyectos);
        }

        /// <summary>
        /// Obtiene un proyecto por su ID.
        /// </summary>
        /// <param name="codProyecto">El ID del proyecto que se desea obtener.</param>
        /// <returns>El proyecto correspondiente al ID proporcionado.</returns>
        [HttpGet("{codProyecto}")]
        public async Task<IActionResult> GetById([FromRoute] int codProyecto)
        {
            var proyecto = await _unitOfWork.ProyectoRepository.GetById(codProyecto);
            if (proyecto == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el proyecto.");
            }
            return ResponseFactory.CreateSuccessResponse(200, proyecto);
        }

        /// <summary>
        /// Obtiene todos los proyectos por su estado.
        /// </summary>
        /// <param name="estadoId">El ID del estado de los proyectos que se desean obtener.</param>
        /// <returns>Una lista de proyectos que tienen el estado correspondiente al ID proporcionado.</returns>
        [HttpGet("estado/{estadoId}")]
        public async Task<IActionResult> GetByEstado([FromRoute] int estadoId)
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetByEstado(estadoId);
            if (proyectos == null)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontraron proyectos con ese estado.");
            }
            return ResponseFactory.CreateSuccessResponse(200, proyectos);
        }

        /// <summary>
        /// Inserta un nuevo proyecto.
        /// </summary>
        /// <param name="dto">Los datos del proyecto que se va a insertar.</param>
        /// <returns>Un mensaje de éxito indicando que el proyecto se registró con éxito.</returns>
        [HttpPost]
        [Route("Insertar")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Insert(ProyectoDTO dto)
        {
            var proyecto = new Proyecto(dto);
            await _unitOfWork.ProyectoRepository.Insertar(proyecto);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Proyecto registrado con éxito.");
        }

        /// <summary>
        /// Modifica un proyecto existente.
        /// </summary>
        /// <param name="codProyecto">El ID del proyecto que se va a modificar.</param>
        /// <param name="dto">Los datos actualizados del proyecto.</param>
        /// <returns>Un mensaje de éxito indicando que el proyecto se modificó con éxito.</returns>
        [HttpPut("{codProyecto}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codProyecto, ProyectoDTO dto)
        {
            var proyecto = new Proyecto(dto, codProyecto);
            var result = await _unitOfWork.ProyectoRepository.Modificar(proyecto);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el proyecto.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Proyecto modificado con éxito.");
        }

        /// <summary>
        /// Elimina un proyecto por su ID.
        /// </summary>
        /// <param name="codProyecto">El ID del proyecto que se va a eliminar.</param>
        /// <returns>Un mensaje de éxito indicando que el proyecto se eliminó con éxito.</returns>
        [HttpDelete("{codProyecto}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codProyecto)
        {
            var result = await _unitOfWork.ProyectoRepository.Eliminar(codProyecto);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se encontró el proyecto.");
            }
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Proyecto eliminado con éxito.");
        }
    }
}
