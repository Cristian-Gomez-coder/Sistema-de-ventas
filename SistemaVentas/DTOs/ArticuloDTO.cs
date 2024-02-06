namespace SistemaVentas.DTOs
{
    public class ArticuloDTO
    {
        public int? IdArticulo { get; set; }
        public int? IdCategoria { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Stock { get; set; }
        public string? Descripcion { get; set; }
    }
}
