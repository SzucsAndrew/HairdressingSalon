using HairdressingSalon.Data.SeedData;

namespace HairdressingSalon.Web.Helper
{
    public class SeedHelper
    {
        public async Task Seed(IServiceProvider serviceProvider)
        {
            var roleSeeder = serviceProvider.GetRequiredService<IRoleSeedService>();
            await roleSeeder.SeedRoleAsync();

            var userSeeder = serviceProvider.GetRequiredService<IUserSeedService>();
            await userSeeder.SeedUserAsync();
        }
    }
}
