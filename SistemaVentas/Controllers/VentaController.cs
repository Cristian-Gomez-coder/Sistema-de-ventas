using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {
        IVentaService ventaService;

        public VentaController(IVentaService service)
        {
            ventaService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ventaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Venta venta)
        {
            ventaService.Save(venta);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Venta venta)
        {
            ventaService.Update(id, venta);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ventaService.Delete(id);
            return Ok();
        }
    }

}
