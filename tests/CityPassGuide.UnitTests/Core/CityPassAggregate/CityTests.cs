using CityPassGuide.Core.CityPassAggregate;
using FluentAssertions;
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
        var city = new City(Name, CountryId, DailyTransportCost);

        // Assert
        city.Name.Should().Be(Name);
        city.CountryId.Should().Be(CountryId);
        city.DailyTransportCost.Should().Be(DailyTransportCost);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenNameEmpty()
    {
        // Act
        var act = () => new City("", CountryId, DailyTransportCost);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Constructor_ShouldThrow_WhenCountryIdIsIncorrect(int countryId)
    {
        // Act
        var act = () => new City(Name, countryId, DailyTransportCost);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenPriceIsNegative()
    {
        // Act
        var act = () => new City(Name, CountryId, -1);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
