using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Data.SeedData
{
    public class BasicSeedServce
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            SeedOrderingHours(modelBuilder);
            SeedServiceList(modelBuilder);//For demo
        }

        private void SeedOrderingHours(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour
                {
                    Id = 1,
                    DayOfWeek = 1,
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0),
                    IsClosed = false
                });

            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour
                {
                    Id = 2,
                    DayOfWeek = 2,
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0),
                    IsClosed = false
                });

            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour
                {
                    Id = 3,
                    DayOfWeek = 3,
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0),
                    IsClosed = false
                });

            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour
                {
                    Id = 4,
                    DayOfWeek = 4,
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0),
                    IsClosed = false
                });

            modelBuilder.Entity<OpeningHour>().HasData(
                new OpeningHour
                {
                    Id = 5,
                    DayOfWeek = 5,
                    OpenTime = new TimeSpan(8, 0, 0),
                    CloseTime = new TimeSpan(17, 0, 0),
                    IsClosed = false
                });

            modelBuilder.Entity<OpeningHour>().HasData(
               new OpeningHour
               {
                   Id = 6,
                   DayOfWeek = 6,
                   OpenTime = TimeSpan.FromSeconds(0),
                   CloseTime = TimeSpan.FromSeconds(0),
                   IsClosed = true
               });

            modelBuilder.Entity<OpeningHour>().HasData(
               new OpeningHour
               {
                   Id = 7,
                   DayOfWeek = 7,
                   OpenTime = TimeSpan.FromSeconds(0),
                   CloseTime = TimeSpan.FromSeconds(0),
                   IsClosed = true
               });
        }

        private void SeedServiceList(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    Duration = new TimeSpan(0,15,0),
                    IsActive = true,
                    Name = "Haircut",
                    Price = 3000
                });

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 2,
                    Duration = new TimeSpan(0, 25, 0),
                    IsActive = true,
                    Name = "Haircut and hair drying",
                    Price = 4500
                });
        }
    }
}
