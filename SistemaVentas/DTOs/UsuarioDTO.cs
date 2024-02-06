namespace SistemaVentas.DTOs
{
    public class UsuarioDTO
    {
        public int? IdUsuario { get; set; }
        public required int IdRol { get; set; }
        public required string Nombre { get; set; }
        public required string TipoDocumento { get; set; }
        public required string NumDocumento { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Email { get; set; }
        public required byte[] Password { get; set; }
    }
}
