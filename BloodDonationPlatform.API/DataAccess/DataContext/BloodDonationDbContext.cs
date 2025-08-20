using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace BloodDonationPlatform.API.DataAccess.DataContext
{
    internal class BloodDonationDbContext : DbContext
    {
        public BloodDonationDbContext(DbContextOptions<BloodDonationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<DonorDonationRequest> DonorDonationRequests { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<BloodType> BloodType { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
