using HairdressingSalon.Data.Constants;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairdressingSalon.Data.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name)
                .HasMaxLength(CustomerConstant.MaxNameLength);

            builder.Property(c => c.BirthDate).IsRequired();

            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(CustomerConstant.MaxPhoneNumberLength);

            builder.Property(c => c.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            builder.Property(c => c.ApplicationUserId).IsRequired();
        }
    }
}
