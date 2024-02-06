namespace SistemaVentas.DTOs
{
    public class ClienteDTO
    {
        public int ? IdCliente { get; set; }
        public required string Nombre { get; set; }
        public required string TipoDocumento { get; set; }
        public required string NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
