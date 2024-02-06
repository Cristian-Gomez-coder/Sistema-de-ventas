namespace SistemaVentas.DTOs
{
    public class CategoriaDTO
    {
        public int? IdCategoria { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
