using HairdressingSalon.Data;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Web.Helper
{
    public class DatabaseIntegrityHelper
    {
        public void CheckMIgration(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<HairdressingSalonDbContext>();
            var migrations = dbContext.Database.GetMigrations().ToHashSet();
            if (dbContext.Database.GetAppliedMigrations().Any(a => !migrations.Contains(a)))
            {
                throw new Exception("Removed migration!");
            }
            dbContext.Database.Migrate();
        }
    }
}
