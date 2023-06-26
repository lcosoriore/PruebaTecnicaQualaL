using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QualaServices.Models;

public partial class QualaDbContext : DbContext
{
    public QualaDbContext()
    {
    }

    public QualaDbContext(DbContextOptions<QualaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.MonedaId);

            entity.Property(e => e.Moneda).HasMaxLength(100);
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Sucursal");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Identificacion).HasMaxLength(50);

            //entity.HasOne(d => d.Moneda).WithMany(p => p.Sucursals)
            //    .HasForeignKey(d => d.MonedaId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Sucursal_Moneda");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
