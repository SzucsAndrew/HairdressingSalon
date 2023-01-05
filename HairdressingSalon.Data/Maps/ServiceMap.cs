using HairdressingSalon.Data.Constants;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairdressingSalon.Data.Maps
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(ServiceConstant.MaxNameLength);
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(s => s.Price).IsRequired()
            .HasColumnType($"decimal({ServiceConstant.Precision},{ServiceConstant.Scale})");

            builder.Property(s => s.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
