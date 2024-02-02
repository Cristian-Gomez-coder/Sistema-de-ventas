using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

namespace SistemaVentas.Services
{
    public class RolService : IRolService
    {
        protected readonly VentasContext _context;

        public RolService(VentasContext dbcontext)
        {
            _context = dbcontext;
        }

        public IEnumerable<Rol> Get()
        {
            return _context.Roles.Include(r => r.Usuarios);
        }

        public async Task Save(Rol rol)
        {
            _context.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Rol rol)
        {
            var rolActual = _context.Roles.Find(id);

            if (rolActual != null)
            {
                rolActual.Nombre = rol.Nombre;
                rolActual.Descripcion = rol.Descripcion;
                rolActual.Estado = rol.Estado;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var rolActual = _context.Roles.Find(id);

            if (rolActual != null)
            {
                _context.Remove(rolActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IRolService
    {
        IEnumerable<Rol> Get();
        Task Save(Rol rol);
        Task Update(int id, Rol rol);
        Task Delete(int id);
    }

}
