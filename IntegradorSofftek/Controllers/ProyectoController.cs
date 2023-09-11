using IntegradorSofftek.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofftek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {

        [HttpPost]
        public IActionResult CrearProyecto([FromBody] ProyectoDTO proyecto)
        {
            //codigo
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProyecto(int id, ProyectoDTO proyecto)
        {
            //codigo
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProyecto(int id)
        {
            //codigo
        }
    }
}
