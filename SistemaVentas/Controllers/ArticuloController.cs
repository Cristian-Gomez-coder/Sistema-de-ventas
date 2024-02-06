using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;
using SistemaVentas.DTOs;

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
            try
            {
                var result = articuloService.Save(articulo);
                if (result.Result != null)
                    return Ok();
                return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error al guardar el artículo: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArticuloDTO articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = articuloService.Update(id, articulo);
                if (result.Result != null)
                    return Ok();
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el artículo: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = articuloService.Delete(id);
                if (result.Result == null)
                    return StatusCode(StatusCodes.Status404NotFound);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el artículo: {ex.Message}");
            }
        }
    }

}
