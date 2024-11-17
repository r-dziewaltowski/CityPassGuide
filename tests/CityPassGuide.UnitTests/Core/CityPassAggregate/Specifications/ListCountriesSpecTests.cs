using CityPassGuide.Core.CityPassAggregate;
using CityPassGuide.Core.CityPassAggregate.Specifications;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityPassAggregate.Specifications;

public class ListCountriesSpecTests
{
    private static readonly List<Country> _entities =
    [
        new("TestCountry1"),
        new("TestCountry2"),
        new("TestCountry3")
    ];

    [Fact]
    public void Evaluate_ShouldSkipCorrectly()
    {
        // Arrange
        var listCountriesSpec = new ListCountriesSpec(pageNumber: 2, pageSize: 1, name: null);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(_entities.GetRange(1, 1));
    }

    [Fact]
    public void Evaluate_ShouldTakeCorrectly()
    {
        // Arrange
        var listCountriesSpec = new ListCountriesSpec(pageNumber: 1, pageSize: 2, name: null);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(_entities.GetRange(0, 2));
    }

    [Theory]
    [InlineData("TestCountry2")]
    [InlineData(" TestCountry2 ")]
    public void Evaluate_ShouldFilterCorrectly(string filterString)
    {
        // Arrange
        var listCountriesSpec = new ListCountriesSpec(pageNumber: 1, pageSize: 10, name: filterString);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(_entities.GetRange(1, 1));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Evaluate_ShouldNotFilter_WhenFilterStringIsWhiteSpace(string filterString)
    {
        // Arrange
        var listCountriesSpec = new ListCountriesSpec(pageNumber: 1, pageSize: 10, name: filterString);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(_entities);
    }
}
