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
        new("Country3"),
    ];

    [Fact]
    public void Evaluate_ShouldSkipCorrectly()
    {
        TestEvaluate(
            pageNumber: 2,
            pageSize: 1,
            filterText: null,
            searchText: null,
            expectedResult: _entities.GetRange(1, 1));
    }

    [Fact]
    public void Evaluate_ShouldTakeCorrectly()
    {
        TestEvaluate(
            pageNumber: 1,
            pageSize: 2,
            filterText: null,
            searchText: null,
            expectedResult: _entities.GetRange(0, 2));
    }

    [Theory]
    [InlineData("TestCountry2")]
    [InlineData(" TestCountry2 ")]
    public void Evaluate_ShouldFilterCorrectly(string filterText)
    {
        TestEvaluate(
            pageNumber: 1,
            pageSize: 10,
            filterText: filterText,
            searchText: null,
            expectedResult: _entities.GetRange(1, 1));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Evaluate_ShouldNotFilter_WhenFilterTextIsWhiteSpace(string filterText)
    {
        TestEvaluate(
            pageNumber: 1,
            pageSize: 10,
            filterText: filterText,
            searchText: null,
            expectedResult: _entities);
    }

    [Theory]
    [InlineData("Test")]
    [InlineData(" Test ")]
    public void Evaluate_ShouldSearchCorrectly(string searchText)
    {
        TestEvaluate(
            pageNumber: 1,
            pageSize: 10,
            filterText: null,
            searchText: searchText,
            expectedResult: _entities.GetRange(0, 2));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Evaluate_ShouldNotSearch_WhenSearchTextIsWhiteSpace(string searchText)
    {
        TestEvaluate(
            pageNumber: 1, 
            pageSize: 10, 
            filterText: null, 
            searchText: searchText, 
            expectedResult: _entities);
    }

    private static void TestEvaluate(
        int pageNumber, 
        int pageSize, 
        string? filterText, 
        string? searchText, 
        List<Country> expectedResult)
    {
        // Arrange
        var listCountriesSpec = new ListCountriesSpec(pageNumber, pageSize, filterText, searchText);

        // Act
        var result = listCountriesSpec.Evaluate(_entities);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}
