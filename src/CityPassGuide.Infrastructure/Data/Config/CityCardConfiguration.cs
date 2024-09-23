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

    builder.OwnsOne(builder => builder.ValidityPeriod);
  }
}
