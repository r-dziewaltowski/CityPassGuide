using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.Infrastructure.Data.Config;

public class AttractionConfiguration : IEntityTypeConfiguration<Attraction>
{
  public void Configure(EntityTypeBuilder<Attraction> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DefaultNameLength)
      .IsRequired();

    builder.HasIndex(p => new
      {
        p.CityId,
        p.Name
      })
      .IsUnique();
  }
}
