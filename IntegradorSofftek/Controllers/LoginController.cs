using IntegradorSofftek.DTOs;
using IntegradorSofftek.Helpers;
using IntegradorSofftek.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofftek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        /// Se loguea un usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>retorna el token del usuario</returns>
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateDTO dto)
        {
            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (userCredentials is null) return Unauthorized("Dni o clave incorrectas");

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UsuarioLoginDTO()
            {
                Nombre = userCredentials.Nombre,
                Dni = userCredentials.Dni,
                Token = token
            };

            return Ok(user);
        }
    }
}
