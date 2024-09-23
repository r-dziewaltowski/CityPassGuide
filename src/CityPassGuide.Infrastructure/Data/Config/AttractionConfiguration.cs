using CityPassGuide.Core.CityCardAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPassGuide.Infrastructure.Data.Config;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
  public void Configure(EntityTypeBuilder<Attraction> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
  }
}
