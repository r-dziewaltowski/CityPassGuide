using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.Infrastructure.Data.Config;

public class CityPassConfiguration : IEntityTypeConfiguration<CityPass>
{
  public void Configure(EntityTypeBuilder<CityPass> builder)
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
      .WithMany(e => e.CityPasses)
      .UsingEntity(
        l => l.HasOne(typeof(Attraction)).WithMany().OnDelete(DeleteBehavior.Restrict),
        r => r.HasOne(typeof(CityPass)).WithMany().OnDelete(DeleteBehavior.Restrict));
  }
}
