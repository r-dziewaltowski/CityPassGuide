using CityPassGuide.Core.CityPassAggregate;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityPassAggregate;
public class AttractionTests
{
    private const string Name = "London Eye";
    private const int CityId = 1;
    private const int Price = 50;

    [Fact]
    public void Constructor_ShouldSetProperties()
    {
        // Act
        var attraction = new Attraction(Name, CityId, Price);

        // Assert
        attraction.Name.Should().Be(Name);
        attraction.CityId.Should().Be(CityId);
        attraction.Price.Should().Be(Price);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenNameEmpty()
    {
        // Act
        var act = () => new Attraction("", CityId, Price);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Constructor_ShouldThrow_WhenCityIdIsIncorrect(int cityId)
    {
        // Act
        var act = () => new Attraction(Name, cityId, Price);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenPriceIsNegative()
    {
        // Act
        var act = () => new Attraction(Name, CityId, -1);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
