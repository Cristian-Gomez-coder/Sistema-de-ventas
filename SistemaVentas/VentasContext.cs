using Microsoft.EntityFrameworkCore;
using SistemaVentas.Models;

public class VentasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<Detalle> Detalles { get; set; }

    public VentasContext(DbContextOptions<VentasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.IdCategoria);
            categoria.Property(p => p.Nombre).IsRequired();
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Estado).HasDefaultValue(true);
        }
        );

        modelBuilder.Entity<Articulo>(articulo =>
        {
            articulo.ToTable("Articulo");
            articulo.HasKey(p =>p.IdArticulo);
            articulo.HasOne(p => p.Categoria).WithMany(p => p.Articulos).HasForeignKey(p => p.IdCategoria);
            articulo.Property(p => p.Codigo).IsRequired(true);
            articulo.Property(p => p.Descripcion).IsRequired(true);
            articulo.Property(p => p.Estado).HasDefaultValue(true);
            articulo.Property(p => p.Nombre).IsRequired(true);
            articulo.Property(p => p.PrecioVenta).HasColumnType("decimal(11,2)").IsRequired(true);
            articulo.Property(p => p.Stock).IsRequired(true);

        });

        modelBuilder.Entity<Cliente>(cliente =>
        {
            cliente.ToTable("Cliente");
            cliente.HasKey(p => p.IdCliente);
            cliente.Property(p => p.Nombre).IsRequired();
            cliente.Property(p => p.TipoDocumento).HasMaxLength(20);
            cliente.Property(p => p.NumDocumento).HasMaxLength(20);
            cliente.Property(p => p.Direccion).HasMaxLength(70);
            cliente.Property(p => p.Telefono).HasMaxLength(20);
            cliente.Property(p => p.Email).HasMaxLength(50);
        });

        modelBuilder.Entity<Rol>(rol =>
        {
            rol.ToTable("Rol");
            rol.HasKey(p => p.IdRol);
            rol.Property(p => p.Nombre).IsRequired();
            rol.Property(p => p.Descripcion).HasMaxLength(100);
            rol.Property(p => p.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario.ToTable("Usuario");
            usuario.HasKey(p => p.IdUsuario);
            usuario.Property(p => p.Nombre).IsRequired();
            usuario.Property(p => p.TipoDocumento).IsRequired().HasMaxLength(20);
            usuario.Property(p => p.NumDocumento).IsRequired().HasMaxLength(20);
            usuario.Property(p => p.Direccion).HasMaxLength(70);
            usuario.Property(p => p.Telefono).HasMaxLength(20);
            usuario.Property(p => p.Email).IsRequired().HasMaxLength(50);
            usuario.Property(p => p.Password).IsRequired();
            usuario.Property(p => p.Estado).HasDefaultValue(true);

            usuario.HasOne(p => p.Rol).WithMany().HasForeignKey(p => p.IdRol).IsRequired();

        });

        modelBuilder.Entity<Detalle>(detalle =>
        {
            detalle.ToTable("Detalle");
            detalle.HasKey(p => p.IdDetalle);
            detalle.Property(p => p.Cantidad).IsRequired();
            detalle.Property(p => p.Precio).HasColumnType("decimal(11,2)").IsRequired();
            detalle.Property(p => p.Descuento).HasColumnType("decimal(11,2)").IsRequired();

            detalle.HasOne(d => d.Articulo)
                .WithMany()
                .HasForeignKey(d => d.IdArticulo)
                .IsRequired();

            detalle.HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity<Venta>(venta =>
        {
            venta.ToTable("Venta");
            venta.HasKey(p => p.IdVenta);
            venta.Property(p => p.TipoComprobante).IsRequired().HasMaxLength(20);
            venta.Property(p => p.SerieComprobante).HasMaxLength(7);
            venta.Property(p => p.NumComprobante).IsRequired().HasMaxLength(10);
            venta.Property(p => p.FechaHora).IsRequired();
            venta.Property(p => p.Total).HasColumnType("decimal(11,2)").IsRequired();
            venta.Property(p => p.Estado).HasDefaultValue(true);

            venta.HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.IdCliente)
                .IsRequired();

            venta.HasOne(v => v.Vendedor)
                .WithMany()
                .HasForeignKey(v => v.IdUsuario)
                .IsRequired();

            venta.HasMany(v => v.Detalles)
                .WithOne(d => d.Venta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

    }
}

