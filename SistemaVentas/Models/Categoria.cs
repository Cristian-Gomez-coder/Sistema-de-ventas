using System.Text.Json.Serialization;
using System.Threading;

namespace SistemaVentas.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [JsonIgnore]
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
