using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        IRolService rolService;

        public RolController(IRolService service)
        {
            rolService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(rolService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rol rol)
        {
            rolService.Save(rol);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Rol rol)
        {
            rolService.Update(id, rol);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            rolService.Delete(id);
            return Ok();
        }
    }

}
