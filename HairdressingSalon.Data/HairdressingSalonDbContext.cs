using HairdressingSalon.Data.Entities;
using HairdressingSalon.Data.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HairdressingSalon.Data
{
    public class HairdressingSalonDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<Service> Services { get; set; }

        public HairdressingSalonDbContext(DbContextOptions<HairdressingSalonDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            new BasicSeedServce().Seed(modelBuilder);
        }
    }
}
