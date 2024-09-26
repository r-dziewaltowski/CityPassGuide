using CityPassGuide.Core.CityCardAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPassGuide.Infrastructure.Data.Config;

public class CityCardConfiguration : IEntityTypeConfiguration<CityCard>
{
  public void Configure(EntityTypeBuilder<CityCard> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.OwnsOne(p => p.ValidityPeriod);

    builder.HasIndex(p => new
      {
        p.CityId,
        p.Name
      })
      .IsUnique();

    builder.HasMany(e => e.Attractions)
      .WithMany(e => e.CityCards)
      .UsingEntity(
        l => l.HasOne(typeof(Attraction)).WithMany().OnDelete(DeleteBehavior.Restrict),
        r => r.HasOne(typeof(CityCard)).WithMany().OnDelete(DeleteBehavior.Restrict));
  }
}
