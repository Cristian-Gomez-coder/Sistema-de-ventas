using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        IArticuloService articuloService;

        public ArticuloController(IArticuloService service)
        {
            articuloService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(articuloService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            articuloService.Save(articulo);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo articulo)
        {
            articuloService.Update(id, articulo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            articuloService.Delete(id);
            return Ok();
        }
    }

}
