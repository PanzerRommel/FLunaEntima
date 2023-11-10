using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class FlunaEntimaContext : DbContext
{
    public FlunaEntimaContext()
    {
    }

    public FlunaEntimaContext(DbContextOptions<FlunaEntimaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatalogoProducto> CatalogoProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-4O6S8T56; Database= FLunaEntima; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatalogoProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Catalogo__09889210B8FAAE24");

            entity.ToTable("CatalogoProducto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
