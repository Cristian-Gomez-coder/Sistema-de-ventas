namespace SistemaVentas.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string TipoComprobante { get; set; }
        public string SerieComprobante { get; set; }
        public string NumComprobante { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Detalle> Detalles { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Vendedor { get; set; }
    }
}
