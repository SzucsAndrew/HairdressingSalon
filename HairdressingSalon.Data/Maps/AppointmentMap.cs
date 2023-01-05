using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairdressingSalon.Data.Maps
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();

            builder.Property(a => a.HairdresserId).IsRequired();
            builder.Property(a => a.CustomerId).IsRequired();
            builder.Property(a => a.ServiceId).IsRequired();

            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.DateTime).IsRequired();

            builder.Property(a => a.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(a => a.Hairdresser)
                .WithMany(h => h.Appointments)
                .HasForeignKey(a => a.HairdresserId)
                .HasPrincipalKey(h => h.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .HasPrincipalKey(c => c.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
