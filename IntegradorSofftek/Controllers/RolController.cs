using IntegradorSofftek.DTOs;
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
        public async Task<ActionResult<IEnumerable<Rol>>> GetAll()
        {
            var Roles = await _unitOfWork.RolRepository.GetAll();

            return Roles;
        }

        [HttpPost]
        [Route("Insertar")]
        public async Task<IActionResult> Insert(RolDTO dto)
        {
            var Rol = new Rol(dto);
            await _unitOfWork.RolRepository.Insertar(Rol);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [Authorize(Policy = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar([FromRoute] int id, Rol rol)
        {
            var result = await _unitOfWork.RolRepository.Modificar(rol);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            var result = await _unitOfWork.RolRepository.Eliminar(id);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
