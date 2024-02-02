using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        IClienteService clienteService;

        public ClienteController(IClienteService service)
        {
            clienteService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(clienteService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            clienteService.Save(cliente);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            clienteService.Update(id, cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            clienteService.Delete(id);
            return Ok();
        }
    }
}
