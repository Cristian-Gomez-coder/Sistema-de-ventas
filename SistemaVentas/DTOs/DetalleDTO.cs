namespace SistemaVentas.DTOs
{
    public class DetalleDTO
    {
        public required ArticuloDTO articulo {  get; set; }

        public required int cantidad {  get; set; }

    }
}
