using System.Text.Json.Serialization;

namespace SistemaVentas.Models
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
