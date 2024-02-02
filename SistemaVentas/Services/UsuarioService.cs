using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class UsuarioService : IUsuarioService
    {
        protected readonly VentasContext _context;

        public UsuarioService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Usuario> Get()
        {
            return _context.Usuarios.Include(u => u.Rol);
        }

        public async Task Save(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Usuario usuario)
        {
            var usuarioActual = _context.Usuarios.Find(id);

            if (usuarioActual != null)
            {
                usuarioActual.IdRol = usuario.IdRol;
                usuarioActual.Nombre = usuario.Nombre;
                usuarioActual.TipoDocumento = usuario.TipoDocumento;
                usuarioActual.NumDocumento = usuario.NumDocumento;
                usuarioActual.Direccion = usuario.Direccion;
                usuarioActual.Telefono = usuario.Telefono;
                usuarioActual.Estado = usuario.Estado;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var usuarioActual = _context.Usuarios.Find(id);

            if (usuarioActual != null)
            {
                _context.Remove(usuarioActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IUsuarioService
    {
        IEnumerable<Usuario> Get();
        Task Save(Usuario usuario);
        Task Update(int id, Usuario usuario);
        Task Delete(int id);
    }

}
