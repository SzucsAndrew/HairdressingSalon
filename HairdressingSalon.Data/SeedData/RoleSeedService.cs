using Microsoft.AspNetCore.Identity;

namespace HairdressingSalon.Data.SeedData
{
    public class RoleSeedService : IRoleSeedService
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RoleSeedService(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRoleAsync()
        {
            var roleList = new []
            {
                RoleHelper.Administrators,
                RoleHelper.Hairdressers,
                RoleHelper.Customers
            };

            foreach (var role in roleList)
            {
                await CreateRoleIfNotExists(role);
            }
        }

        private async Task CreateRoleIfNotExists(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole<int> { Name = role });
            }
        }
    }
}
