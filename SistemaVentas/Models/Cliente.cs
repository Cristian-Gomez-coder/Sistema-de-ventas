﻿using System.Text.Json.Serialization;

namespace SistemaVentas.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public required string Nombre { get; set; }
        public required string TipoDocumento { get; set; }
        public required string NumDocumento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Venta> Compras { get; set; }

    }
}
