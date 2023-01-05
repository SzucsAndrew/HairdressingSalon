using Microsoft.AspNetCore.Identity;

namespace HairdressingSalon.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
