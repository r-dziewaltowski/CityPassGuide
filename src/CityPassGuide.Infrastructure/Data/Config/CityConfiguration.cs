using CityPassGuide.Core.CityPassAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPassGuide.Infrastructure.Data.Config;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
  public void Configure(EntityTypeBuilder<City> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasIndex(p => new
      {
        p.CountryId,
        p.Name
      })
      .IsUnique();
  }
}
