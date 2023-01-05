using HairdressingSalon.Data;
using HairdressingSalon.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Web.Helper.DepedencyInjectionHelper
{
    public static class DataDepedencyInjection
    {
        public static void AddDataLayer(this IServiceCollection service, IConfigurationRoot configuration)
        {
            AddDatabase(service, configuration);
            AddDataServices(service);
        }

        private static void AddDatabase(IServiceCollection service, IConfigurationRoot configuration)
        {
            service.AddDbContext<HairdressingSalonDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HairdressingSalonDb"));
            });
        }

        private static void AddDataServices(IServiceCollection service)
        {
            service.AddScoped<IRoleSeedService, RoleSeedService>();
            service.AddScoped<IUserSeedService, UserSeedService>();
        }
    }
}
