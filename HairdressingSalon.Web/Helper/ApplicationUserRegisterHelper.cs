using HairdressingSalon.Data.Entities;
using HairdressingSalon.Data.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairdressingSalon.Web.Helper
{
    public class ApplicationUserRegisterHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRegisterHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GenerateHairdresser(string name)
        {
            var email = GenerateEmailAddress(name);
            var applicationUser = new ApplicationUser
            {
                Email = email,
                Name = name,
                UserName = email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(applicationUser, "P@ssword");
            if (!result.Succeeded)
            {
                throw new Exception("Cannot create application user.");
            }

            await _userManager.AddToRoleAsync(applicationUser, RoleHelper.Hairdressers);

            return applicationUser;
        }

        private string GenerateEmailAddress(string name)
        {
            return $"{name.Replace(" ", "").ToLower()}@salon.com";
        }

        public async Task LockoutTheUser(int applicationUserId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == applicationUserId);
            user.LockoutEnd = DateTime.MaxValue;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Cannot lock out the user");
            }
        }

        public async Task UnLockoutTheUser(int applicationUserId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == applicationUserId);
            user.LockoutEnd = null;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Cannot unlock the user");
            }
        }
    }
}
