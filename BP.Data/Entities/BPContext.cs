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
        }

        private void BuildVehicles(ModelBuilder modelBuilder)
        {
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
        }

        private void BuildDrivers(ModelBuilder modelBuilder)
        {
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
        }
    }
}

