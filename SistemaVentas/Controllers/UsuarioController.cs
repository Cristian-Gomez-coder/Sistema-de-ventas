using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService service)
        {
            usuarioService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usuarioService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            usuarioService.Save(usuario);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            usuarioService.Update(id, usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            usuarioService.Delete(id);
            return Ok();
        }
    }

}
