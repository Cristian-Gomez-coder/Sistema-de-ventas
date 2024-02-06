namespace SistemaVentas.DTOs
{
    public class VentaDTO
    {
        public required int IdCliente {  get; set; }
        public required int IdUsuario { get; set; }
        public required List<DetalleDTO> Detalles { get; set; }
        public required string TipoComprobante { get; set; }
        public required string SerieComprobante { get; set; }
        public required string NumComprobante { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public decimal? Total { get; set; }
    }
}
