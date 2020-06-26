using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Entities
{
    public class BPContext : DbContext
    {
        public BPContext(DbContextOptions<BPContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VehicleRent> VehicleRents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildCustomers(modelBuilder);
            BuildDrivers(modelBuilder);
            BuildVehicles(modelBuilder);
            BuildOrders(modelBuilder);
            BuildVehicleRents(modelBuilder);
        }

        private void BuildVehicleRents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleRent>()
                .Property(x => x.VehicleRentID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }

        private void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Order>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }

        private void BuildVehicles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .Property(x => x.VehicleID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Vehicle>()
                .Property(x => x.Type)
                .HasMaxLength(63)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(x => x.NumberPlate)
                .HasMaxLength(31)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(x => x.Colour)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }

        private void BuildDrivers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .Property(x => x.DriverID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Driver>()
                .Property(x => x.FirstName)
                .HasMaxLength(31)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(x => x.Surname)
                .HasMaxLength(31)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired(); 
        }

        private void BuildCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Customer>()
                .Property(x => x.FirstName)
                .HasMaxLength(31)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Surname)
                .HasMaxLength(31)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}

