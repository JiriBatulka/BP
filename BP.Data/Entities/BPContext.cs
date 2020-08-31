using Microsoft.EntityFrameworkCore;

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
        public DbSet<UserIdentity> UserIdentities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildCustomers(modelBuilder);
            BuildDrivers(modelBuilder);
            BuildVehicles(modelBuilder);
            BuildOrders(modelBuilder);
            BuildVehicleRents(modelBuilder);
            BuildUserIdentity(modelBuilder);
        }

        private void BuildUserIdentity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserIdentity>()
                .Property(x => x.UserIdentityID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<UserIdentity>()
                .Property(x => x.Username)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<UserIdentity>()
                .HasIndex(b => b.Username)
                .IsUnique();

            modelBuilder.Entity<UserIdentity>()
                .Property(x => x.Role)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<UserIdentity>()
                .Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<UserIdentity>()
                .Property(x => x.PasswordSalt)
                .IsRequired()
                .HasMaxLength(255);
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
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(x => x.NumberPlate)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .Property(x => x.Colour)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.IsActive)
                .HasDefaultValue(false);
        }

        private void BuildDrivers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .Property(x => x.DriverID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Driver>()
                .Property(x => x.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(x => x.Surname)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Driver>()
                .Property(x => x.PhoneNumber)
                .HasMaxLength(255)
                .IsRequired(); 
        }

        private void BuildCustomers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerID)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            modelBuilder.Entity<Customer>()
                .Property(x => x.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Surname)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.PhoneNumber)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.IsActive)
                .HasDefaultValue(false);
        }
    }
}

