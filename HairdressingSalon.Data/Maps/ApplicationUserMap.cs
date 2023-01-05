using HairdressingSalon.Data.Constants;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairdressingSalon.Data.Maps
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");
            builder.Property(a => a.Name).HasMaxLength(ApplicationUserConstant.MaxNameLength);
        }
    }
}
