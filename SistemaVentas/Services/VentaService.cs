using Microsoft.EntityFrameworkCore;
using SistemaVentas.DTOs;
using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class VentaService : IVentaService
    {
        protected readonly VentasContext _context;

        public VentaService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Venta> Get()
        {
            return _context.Ventas
                .Include(v => v.Detalles)
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor);
        }

        public async Task Save(Venta venta)
        {
            _context.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Venta venta)
        {
            var ventaActual = _context.Ventas.Find(id);

            if (ventaActual != null)
            {
                ventaActual.IdCliente = venta.IdCliente;
                ventaActual.IdUsuario = venta.IdUsuario;
                ventaActual.TipoComprobante = venta.TipoComprobante;
                ventaActual.SerieComprobante = venta.SerieComprobante;
                ventaActual.NumComprobante = venta.NumComprobante;
                ventaActual.FechaHora = venta.FechaHora;
                ventaActual.Total = venta.Total;
                ventaActual.Estado = venta.Estado;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var ventaActual = _context.Ventas.Find(id);

            if (ventaActual != null)
            {
                _context.Remove(ventaActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IVentaService
    {
        IEnumerable<Venta> Get();
        Task Save(Venta venta);
        Task Update(int id, Venta venta);
        Task Delete(int id);
    }

}
