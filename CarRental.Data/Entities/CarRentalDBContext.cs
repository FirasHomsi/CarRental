using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRental.Data.Entities
{
  public partial class CarRentalDBContext : DbContext
  {
    public CarRentalDBContext()
    {
    }

    public CarRentalDBContext(DbContextOptions<CarRentalDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VehicleBrands> VehicleBrands { get; set; }
    public virtual DbSet<VehicleColors> VehicleColors { get; set; }
    public virtual DbSet<VehicleFuelTypes> VehicleFuelTypes { get; set; }
    public virtual DbSet<VehicleModels> VehicleModels { get; set; }
    public virtual DbSet<Vehicles> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Server=DESKTOP-3KTNVKB;Database=CarRentalDB;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<VehicleBrands>(entity =>
      {
        entity.HasKey(e => e.Idbrand);

        entity.Property(e => e.Idbrand).HasColumnName("IDBrand");

        entity.Property(e => e.BrandName)
                  .IsRequired()
                  .HasMaxLength(255);
      });

      modelBuilder.Entity<VehicleColors>(entity =>
      {
        entity.HasKey(e => e.Idcolor)
                  .HasName("PK_VehicleColors_1");

        entity.Property(e => e.Idcolor).HasColumnName("IDColor");

        entity.Property(e => e.VehicleColor)
                  .IsRequired()
                  .HasMaxLength(255);
      });

      modelBuilder.Entity<VehicleFuelTypes>(entity =>
      {
        entity.HasKey(e => e.VehicleFuelTypeName);

        entity.Property(e => e.VehicleFuelTypeName).HasMaxLength(255);

        entity.Property(e => e.Observations).HasMaxLength(255);
      });

      modelBuilder.Entity<VehicleModels>(entity =>
      {
        entity.HasKey(e => new { e.Idmodel, e.Idbrand })
                  .HasName("PK_VehicleModels_1");

        entity.Property(e => e.Idmodel)
                  .HasColumnName("IDModel")
                  .ValueGeneratedOnAdd();

        entity.Property(e => e.Idbrand).HasColumnName("IDBrand");

        entity.Property(e => e.ModelName)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.HasOne(d => d.IdbrandNavigation)
                  .WithMany(p => p.VehicleModels)
                  .HasForeignKey(d => d.Idbrand)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_VehicleModels_VehicleBrands1");
      });

      modelBuilder.Entity<Vehicles>(entity =>
      {
        entity.HasKey(e => e.SerialNumber);

        entity.Property(e => e.SerialNumber).HasMaxLength(17);

        entity.Property(e => e.Idbrand).HasColumnName("IDBrand");

        entity.Property(e => e.Idcolor).HasColumnName("IDColor");

        entity.Property(e => e.Idmodel).HasColumnName("IDModel");

        entity.Property(e => e.Observations).HasMaxLength(255);

        entity.Property(e => e.VehicleFuelTypeName)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.HasOne(d => d.IdcolorNavigation)
                  .WithMany(p => p.Vehicles)
                  .HasForeignKey(d => d.Idcolor)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Vehicles_VehicleColors1");

        entity.HasOne(d => d.VehicleFuelTypeNameNavigation)
                  .WithMany(p => p.Vehicles)
                  .HasForeignKey(d => d.VehicleFuelTypeName)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Vehicles_VehicleFuelTypes");

        entity.HasOne(d => d.Id)
                  .WithMany(p => p.Vehicles)
                  .HasForeignKey(d => new { d.Idmodel, d.Idbrand })
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Vehicles_VehicleModels");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
