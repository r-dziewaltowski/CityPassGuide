using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.Infrastructure.Data.Config;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DefaultNameLength)
      .IsRequired();

    builder.HasIndex(p => p.Name)
      .IsUnique();
  }
}
