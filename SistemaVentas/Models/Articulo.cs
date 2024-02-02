using System.Text.Json.Serialization;

namespace SistemaVentas.Models
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
    }
}
