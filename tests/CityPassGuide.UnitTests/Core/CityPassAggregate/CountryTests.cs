using CityPassGuide.Core.CityPassAggregate;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityPassAggregate;
public class CountryTests
{
  private const string Name = "UK";

  [Fact]
  public void Constructor_ShouldSetProperties()
  {
    // Act
    var country = new Country(Name);

    // Assert
    country.Name.Should().Be(Name);
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenNameEmpty()
  {
    // Act
    var act = () => new Country("");

    // Assert
    act.Should().Throw<ArgumentException>();
  }
}
