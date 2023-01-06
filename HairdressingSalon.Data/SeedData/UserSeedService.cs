using HairdressingSalon.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace HairdressingSalon.Data.SeedData
{
    public class UserSeedService : IUserSeedService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserSeedService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            await AddUser("admin@salon.com", "Administrator", RoleHelper.Administrators);
            //await AddUser("hairdresser@salon.com", "Test Hairdresser", RoleHelper.Hairdressers);
            //await AddUser("customer@salon.com", "Test Customer", RoleHelper.Customers);
        }

        private async Task AddUser(string email, string name, string role)
        {
            if (!(await _userManager.GetUsersInRoleAsync(role)).Any())
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Name = name,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                var createResult = await _userManager.CreateAsync(applicationUser, "P@ssword");

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                    var result = await _userManager.ConfirmEmailAsync(applicationUser, code);
                }

                var addToRoleResult = await _userManager.AddToRoleAsync(applicationUser, role);

                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                {
                    throw new ApplicationException("The (default) user could not be created." +
                        string.Join(",", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description)));
                }
            }
        }

    }
}
