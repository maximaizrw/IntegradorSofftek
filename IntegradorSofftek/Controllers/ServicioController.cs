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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _unitOfWork.ServicioRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, servicios);
        }

        [HttpPost]
        [Route("Insertar")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Insert(ServicioDTO dto)
        { 
            var Servicio = new Servicio(dto);
            await _unitOfWork.ServicioRepository.Insertar(Servicio);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito!");
        }

        [HttpPut("{codServicio}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int codServicio, ServicioDTO dto)
        {
            var Servicio = new Servicio(dto, codServicio);
            var result = await _unitOfWork.ServicioRepository.Modificar(Servicio);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el servicio");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Servicio modificado con exito!");
        }

        [HttpDelete("{codServicio}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int codServicio)
        {
            var result = await _unitOfWork.ServicioRepository.Eliminar(codServicio);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el servicio");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Servicio eliminado con exito!");
        }

    }
}
