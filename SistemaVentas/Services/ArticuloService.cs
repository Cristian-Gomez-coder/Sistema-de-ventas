using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class ArticuloService : IArticuloService
    {
        protected readonly VentasContext _context;

        public ArticuloService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Articulo> Get()
        {
            return _context.Articulos.Include(a => a.Categoria);
        }

        public async Task Save(Articulo articulo)
        {
            _context.Add(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Articulo articulo)
        {
            var articuloActual = _context.Articulos.Find(id);

            if (articuloActual != null)
            {
                articuloActual.IdCategoria = articulo.IdCategoria;
                articuloActual.Codigo = articulo.Codigo;
                articuloActual.Nombre = articulo.Nombre;
                articuloActual.PrecioVenta = articulo.PrecioVenta;
                articuloActual.Stock = articulo.Stock;
                articuloActual.Descripcion = articulo.Descripcion;
                articuloActual.Estado = articulo.Estado;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var articuloActual = _context.Articulos.Find(id);

            if (articuloActual != null)
            {
                _context.Remove(articuloActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IArticuloService
    {
        IEnumerable<Articulo> Get();
        Task Save(Articulo articulo);
        Task Update(int id, Articulo articulo);
        Task Delete(int id);
    }

}
