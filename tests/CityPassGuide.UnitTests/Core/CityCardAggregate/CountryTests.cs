using CityPassGuide.Core.CityCardAggregate;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityCardAggregate;
public class CountryTests
{
  private const string Name = "UK";

  [Fact]
  public void Constructor_ShouldSetProperties()
  {
    // Act
    var country = new Country(Name);

    // Assert
    Assert.Equal(Name, country.Name);
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenNameEmpty()
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new Country(""));
  }
}
