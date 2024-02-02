using System.Text.Json.Serialization;

namespace SistemaVentas.Models
{
    public class Detalle
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }

        [JsonIgnore]
        public virtual Articulo Articulo { get; set; }
        [JsonIgnore]
        public virtual Venta Venta { get; set; }
    }
}
