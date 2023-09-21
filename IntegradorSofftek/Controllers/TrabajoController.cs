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

        [HttpGet]
        public async Task<IActionResult> ObtenerTrabajos()
        {
            var trabajos = await _unitOfWork.TrabajoRepository.ObtenerTrabajos();

            return ResponseFactory.CreateSuccessResponse(200, trabajos);
        }

        [HttpGet("{codTrabajo}")]
        public async Task<IActionResult> ObtenerTrabajo([FromRoute] int codTrabajo)
        {
            var trabajo = await _unitOfWork.TrabajoRepository.ObtenerTrabajo(codTrabajo);

            return ResponseFactory.CreateSuccessResponse(200, trabajo);
        }

        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [Route("Insertar")]
        public async Task<IActionResult> Insertar(TrabajoDTO dto)
        {
            var trabajo = new Trabajo(dto);
            await _unitOfWork.TrabajoRepository.Insertar(trabajo);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con exito!");
        }

        [HttpPut("{codTrabajo}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codTrabajo, TrabajoDTO dto)
        {
            var trabajo = new Trabajo(dto, codTrabajo);
            var result = await _unitOfWork.TrabajoRepository.Modificar(trabajo);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el trabajo");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Trabajo modificado con exito!");
        }

        [HttpDelete("{codTrabajo}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codTrabajo)
        {
            var result = await _unitOfWork.TrabajoRepository.Eliminar(codTrabajo);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el trabajo");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Trabajo eliminado con exito!");
        }


    }
}

