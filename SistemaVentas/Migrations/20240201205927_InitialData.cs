using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulo_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RolIdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    TipoComprobante = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SerieComprobante = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    NumComprobante = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.IdVenta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    IdArticulo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(11,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_Detalle_Articulo_IdArticulo",
                        column: x => x.IdArticulo,
                        principalTable: "Articulo",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Venta_IdVenta",
                        column: x => x.IdVenta,
                        principalTable: "Venta",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulo_IdCategoria",
                table: "Articulo",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_IdArticulo",
                table: "Detalle",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_IdVenta",
                table: "Detalle",
                column: "IdVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolIdRol",
                table: "Usuario",
                column: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteIdCliente",
                table: "Venta",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdCliente",
                table: "Venta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdUsuario",
                table: "Venta",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
