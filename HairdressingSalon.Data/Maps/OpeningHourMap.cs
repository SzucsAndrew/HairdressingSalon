using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairdressingSalon.Data.Maps
{
    public class OpeningHourMap : IEntityTypeConfiguration<OpeningHour>
    {
        public void Configure(EntityTypeBuilder<OpeningHour> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();

            builder.Property(o => o.DayOfWeek).IsRequired();
            builder.Property(o => o.OpenTime).IsRequired();
            builder.Property(o => o.CloseTime).IsRequired();

            builder.Property(o => o.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
