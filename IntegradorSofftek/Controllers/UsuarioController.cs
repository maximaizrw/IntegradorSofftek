using IntegradorSofftek.DTOs;
using IntegradorSofftek.Models;
using IntegradorSofftek.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            return usuarios;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registro(RegistroDTO dto)
        {
            var user = new Usuario(dto);
            await _unitOfWork.UsuarioRepository.Insertar(user);
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpPut("{codUsuario}")]
        public async Task<IActionResult> Modificar([FromRoute] int codUsuario, RegistroDTO dto)
        {
            var result = await _unitOfWork.UsuarioRepository.Modificar(new Usuario(dto, codUsuario));
            await _unitOfWork.Complete();
            return Ok(true);
        }

        [HttpDelete("{codUsuario}")]
        public async Task<IActionResult> Eliminar([FromRoute] int codUsuario)
        {
            var result = await _unitOfWork.UsuarioRepository.Eliminar(codUsuario);
            await _unitOfWork.Complete();
            return Ok(true);
        }
    }
}
