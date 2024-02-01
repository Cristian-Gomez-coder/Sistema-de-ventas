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

        public virtual Articulo Articulo { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
