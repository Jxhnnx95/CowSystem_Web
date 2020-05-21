using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CowSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<EstadoGanado> EstadoGanado { get; set; }
        public virtual DbSet<Ganado> Ganado { get; set; }
        public virtual DbSet<Gasto> Gasto { get; set; }
        public virtual DbSet<HistorialFinanciero> HistorialFinanciero { get; set; }
        public virtual DbSet<TipoBalance> TipoBalance { get; set; }
        public virtual DbSet<TipoGanado> TipoGanado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdRegistro);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Identificador).HasMaxLength(50);

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tabla).HasMaxLength(50);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EstadoGanado>(entity =>
            {
                entity.HasKey(e => e.IdEstadoGanado);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<Ganado>(entity =>
            {
                entity.HasKey(e => e.IdGanado);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");

                entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.ValorPeso).HasColumnType("datetime");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Ganado)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_Ganado_EstadoGanado");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Ganado)
                    .HasForeignKey(d => d.Tipo)
                    .HasConstraintName("FK_Ganado_TipoGanado");
            });

            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.IdGasto);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Factura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Proveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<HistorialFinanciero>(entity =>
            {
                entity.HasKey(e => e.IdHistorial);

                entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdGanadoNavigation)
                    .WithMany(p => p.HistorialFinanciero)
                    .HasForeignKey(d => d.IdGanado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialFinanciero_Ganado");

                entity.HasOne(d => d.IdGastoNavigation)
                    .WithMany(p => p.HistorialFinanciero)
                    .HasForeignKey(d => d.IdGasto)
                    .HasConstraintName("FK_HistorialFinanciero_Gasto");

                entity.HasOne(d => d.IdTipoBalanceNavigation)
                    .WithMany(p => p.HistorialFinanciero)
                    .HasForeignKey(d => d.IdTipoBalance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistorialFinanciero_TipoBalance");
            });

            modelBuilder.Entity<TipoBalance>(entity =>
            {
                entity.HasKey(e => e.IdTipoBalance);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<TipoGanado>(entity =>
            {
                entity.HasKey(e => e.IdTipoGanado);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UltimaActualizacion).HasColumnType("datetime");
            });
        }
    }
}
