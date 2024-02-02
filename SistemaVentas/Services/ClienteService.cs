using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class ClienteService : IClienteService
    {
        protected readonly VentasContext _context;

        public ClienteService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Cliente> Get()
        {
            return _context.Clientes;
        }

        public async Task Save(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Cliente cliente)
        {
            var clienteActual = _context.Clientes.Find(id);

            if (clienteActual != null)
            {
                clienteActual.Nombre = cliente.Nombre;
                clienteActual.TipoDocumento = cliente.TipoDocumento;
                clienteActual.NumDocumento = cliente.NumDocumento;
                clienteActual.Direccion = cliente.Direccion;
                clienteActual.Telefono = cliente.Telefono;
                clienteActual.Email = cliente.Email;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var clienteActual = _context.Clientes.Find(id);

            if (clienteActual != null)
            {
                _context.Remove(clienteActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IClienteService
    {
        IEnumerable<Cliente> Get();
        Task Save(Cliente cliente);
        Task Update(int id, Cliente cliente);
        Task Delete(int id);
    }

}
