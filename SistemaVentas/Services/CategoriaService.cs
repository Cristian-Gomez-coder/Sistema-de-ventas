using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class CategoriaService : ICategoriaService
    {
        protected readonly VentasContext _context;

        public CategoriaService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias.Include(c => c.Articulos);
        }

        public async Task Save(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Categoria categoria)
        {
            var categoriaActual = _context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Estado = categoria.Estado;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var categoriaActual = _context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                _context.Remove(categoriaActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(int id, Categoria categoria);
        Task Delete(int id);
    }

}
