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

        [HttpGet]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            var Roles = await _unitOfWork.RolRepository.GetAll();

            return ResponseFactory.CreateSuccessResponse(200, Roles);
        }

        [HttpPost]
        [Authorize(Policy = "Administrador")]
        [Route("Insertar")]
        public async Task<IActionResult> Insert(RolDTO dto)
        {
            var Rol = new Rol(dto);
            await _unitOfWork.RolRepository.Insertar(Rol);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(201, "Rol registrado con exito!");
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Modificar([FromRoute] int id, RolDTO dto)
        {
            var Rol = new Rol(dto, id);
            var result = await _unitOfWork.RolRepository.Modificar(Rol);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el Rol");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Rol modificado con exito!");
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            var result = await _unitOfWork.RolRepository.Eliminar(id);
            if (!result) return ResponseFactory.CreateErrorResponse(500, "No se encontro el Rol");
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Rol eliminado con exito!");
        }
    }
}
