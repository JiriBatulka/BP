using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BP.Entities
{
    public partial class BPContext : DbContext
    {
        public BPContext()
        {
        }

        public BPContext(DbContextOptions<BPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleRent> VehicleRent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BP;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(31)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(31)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(31);

                entity.Property(e => e.Surname).HasMaxLength(31);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.EndTimeEstimate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.HasOne(d => d.Client)
                    .WithMany()
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientID_Order");

                entity.HasOne(d => d.Vehicle)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleID_Order");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleId)
                    .HasColumnName("VehicleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Colour)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.Spz)
                    .IsRequired()
                    .HasColumnName("SPZ")
                    .HasMaxLength(15);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(31);
            });

            modelBuilder.Entity<VehicleRent>(entity =>
            {
                entity.Property(e => e.VehicleRentId)
                    .HasColumnName("VehicleRentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.TimeFrom).HasColumnType("datetime");

                entity.Property(e => e.TimeUntil).HasColumnType("datetime");

                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.VehicleRent)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DriverID_VehicleRent");

                entity.HasOne(d => d.VehicleRentNavigation)
                    .WithOne(p => p.VehicleRent)
                    .HasForeignKey<VehicleRent>(d => d.VehicleRentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleID_VehicleRent");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
