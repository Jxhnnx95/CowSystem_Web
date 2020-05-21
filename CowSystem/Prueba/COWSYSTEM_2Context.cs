using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CowSystem.Prueba
{
    public partial class COWSYSTEM_2Context : DbContext
    {
        public COWSYSTEM_2Context()
        {
        }

        public COWSYSTEM_2Context(DbContextOptions<COWSYSTEM_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<EstadoGanado> EstadoGanado { get; set; }
        public virtual DbSet<Ganado> Ganado { get; set; }
        public virtual DbSet<Gasto> Gasto { get; set; }
        public virtual DbSet<HistorialFinanciero> HistorialFinanciero { get; set; }
        public virtual DbSet<TipoBalance> TipoBalance { get; set; }
        public virtual DbSet<TipoGanado> TipoGanado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=JOHNNY-PC\\SQLSERVER;Database=COWSYSTEM_2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

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
