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
        var listCountriesSpec = new ListCountriesSpec(2, 1);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(_entities.GetRange(1, 1));
    }

    [Fact]
    public void Evaluate_ShouldTakeCorrectly()
    {
        // Arrange
        var listCountriesSpec = new ListCountriesSpec(1, 2);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(_entities.GetRange(0, 2));
    }
}
