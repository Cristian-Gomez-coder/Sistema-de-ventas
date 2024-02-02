using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class DetalleService : IDetalleService
    {
        protected readonly VentasContext _context;

        public DetalleService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Detalle> Get()
        {
            return _context.Detalles.Include(d => d.Articulo).Include(d => d.Venta);
        }

        public async Task Save(Detalle detalle)
        {
            _context.Add(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Detalle detalle)
        {
            var detalleActual = _context.Detalles.Find(id);

            if (detalleActual != null)
            {
                detalleActual.IdVenta = detalle.IdVenta;
                detalleActual.IdArticulo = detalle.IdArticulo;
                detalleActual.Cantidad = detalle.Cantidad;
                detalleActual.Precio = detalle.Precio;
                detalleActual.Descuento = detalle.Descuento;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var detalleActual = _context.Detalles.Find(id);

            if (detalleActual != null)
            {
                _context.Remove(detalleActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IDetalleService
    {
        IEnumerable<Detalle> Get();
        Task Save(Detalle detalle);
        Task Update(int id, Detalle detalle);
        Task Delete(int id);
    }

}
