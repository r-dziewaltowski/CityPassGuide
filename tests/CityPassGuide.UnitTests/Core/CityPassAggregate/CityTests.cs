using CityPassGuide.Core.CityPassAggregate;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityPassAggregate;
public class CityTests
{
  private const string Name = "Edinburgh";
  private const int CountryId = 1;
  private const int DailyTransportCost = 15;

  [Fact]
  public void Constructor_ShouldSetProperties()
  {
    // Act
    var country = new City(Name, CountryId, DailyTransportCost);

    // Assert
    Assert.Equal(Name, country.Name);
    Assert.Equal(CountryId, country.CountryId);
    Assert.Equal(DailyTransportCost, country.DailyTransportCost);
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenNameEmpty()
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new City("", CountryId, DailyTransportCost));
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void Constructor_ShouldThrow_WhenCountryIdIsIncorrect(int countryId)
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new City(Name, countryId, DailyTransportCost));
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenPriceIsNegative()
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new City(Name, CountryId, -1));
  }
}
