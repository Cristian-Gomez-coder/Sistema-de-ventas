using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;
using SistemaVentas.DTOs;
using Microsoft.AspNetCore.Mvc;


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
            return _context.Articulos.Include(c => c.Categoria);
        }

        public async Task<Articulo?> Save(Articulo articulo)
        {
            try
            {
                var categoriaExistente = _context.Categorias.FirstOrDefault(a => a.IdCategoria == articulo.IdCategoria);
                if (categoriaExistente != null)
                {
                    _context.Add(articulo);
                    await _context.SaveChangesAsync();
                    return articulo;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el artículo: {ex.Message}", ex);
            }
        }

        public async Task<Articulo?> Update(int id, ArticuloDTO articulo)
        {
            var articuloActual = _context.Articulos.FirstOrDefault(a => a.IdArticulo == id);
            var categoriaExistente = _context.Categorias.FirstOrDefault(a => a.IdCategoria == articulo.IdCategoria);
            if (articuloActual != null)
            {
                // Actualizar solo las propiedades no nulas del DTO
                if (articulo.IdCategoria != null && categoriaExistente != null)
                    articuloActual.IdCategoria = (int)articulo.IdCategoria;
                if (articulo.Codigo != null)
                    articuloActual.Codigo = articulo.Codigo;
                if (articulo.Nombre != null)
                    articuloActual.Nombre = articulo.Nombre;
                if (articulo.PrecioVenta != null)
                    articuloActual.PrecioVenta = (decimal)articulo.PrecioVenta;
                if (articulo.Stock != null)
                    articuloActual.Stock = (int)articulo.Stock;
                if (articulo.Descripcion != null)
                    articuloActual.Descripcion = articulo.Descripcion;

                await _context.SaveChangesAsync();
            }
            return articuloActual;
        }

        public async Task<Articulo?> Delete(int id)
        {
            var articuloActual = _context.Articulos.FirstOrDefault(a => a.IdArticulo == id);
            Console.Write(articuloActual);
            if (articuloActual != null)
            {
                _context.Articulos.Remove(articuloActual);
                await _context.SaveChangesAsync();
                
            }
           return articuloActual;
        }

    }

    public interface IArticuloService
    {
        IEnumerable<Articulo?> Get();
        Task<Articulo?> Save(Articulo articulo);
        Task<Articulo?> Update(int id, ArticuloDTO articulo);
        Task<Articulo?> Delete(int id);
    }

}
