using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    public class DetalleController : ControllerBase
    {
        IDetalleService detalleService;

        public DetalleController(IDetalleService service)
        {
            detalleService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(detalleService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Detalle detalle)
        {
            detalleService.Save(detalle);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Detalle detalle)
        {
            detalleService.Update(id, detalle);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            detalleService.Delete(id);
            return Ok();
        }
    }

}
