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

        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, proyectos);
        }



        [HttpGet("{codProyecto}")]
        public async Task<IActionResult> GetById([FromRoute] int codProyecto)
        {
            var proyecto = await _unitOfWork.ProyectoRepository.GetById(codProyecto);
            if (proyecto == null) return ResponseFactory.CreateErrorResponse(500, "No se encontro el proyecto");
            return ResponseFactory.CreateSuccessResponse(200, proyecto);
        }

        [HttpGet("estado/{estadoId}")]
        public async Task<IActionResult> GetByEstado([FromRoute] int estadoId)
        {
            var proyectos = await _unitOfWork.ProyectoRepository.GetByEstado(estadoId);
            if (proyectos == null) return ResponseFactory.CreateErrorResponse(500, "No se encontro el proyecto");
            return ResponseFactory.CreateSuccessResponse(200, proyectos);
        }

        [HttpPost]
        [Route("Insertar")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Insert(ProyectoDTO dto)
        {
            var Proyecto = new Proyecto(dto);
            await _unitOfWork.ProyectoRepository.Insertar(Proyecto);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Proyecto registrado con exito!");
        }

        [HttpPut("{codProyecto}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codProyecto, ProyectoDTO dto)
        {
            var proyecto = new Proyecto(dto, codProyecto);
            var result = await _unitOfWork.ProyectoRepository.Modificar(proyecto);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el proyecto");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Proyecto modificado con exito!");
        }

        [HttpDelete("{codProyecto}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codProyecto)
        {
            var result = await _unitOfWork.ProyectoRepository.Eliminar(codProyecto);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el proyecto");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Proyecto eliminado con exito!");
        }

    }
}
