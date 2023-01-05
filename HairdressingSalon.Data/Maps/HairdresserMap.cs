using HairdressingSalon.Data.Constants;
using HairdressingSalon.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HairdressingSalon.Data.Maps
{
    public class HairdresserMap : IEntityTypeConfiguration<Hairdresser>
    {
        public void Configure(EntityTypeBuilder<Hairdresser> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).UseIdentityColumn();

            builder.Property(h => h.Name).IsRequired();
            builder.Property(h => h.Name)
                .HasMaxLength(HairdresserConstant.MaxNameLength);

            builder.Property(c => c.BirthDate).IsRequired();

            builder.Property(h => h.ImageName).IsRequired();
            builder.Property(h => h.ImageName)
                .HasMaxLength(HairdresserConstant.MaxImagePathLength);

            builder.Property(h => h.IntroduceHtml)
                .HasMaxLength(HairdresserConstant.MaxIntroduceLength);

            builder.Property(h => h.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
