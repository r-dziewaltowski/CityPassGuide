using FluentAssertions;
using Xunit;
using CityPassGuide.Core.CityPassAggregate.Specifications;

namespace CityPassGuide.UnitTests.Core.CityPassAggregate.Specifications;

public class ListCountriesSpecTests
{
  [Fact]
  public void Constructor_ShouldSetSkipAndTakeCorrectly()
  {
    // Act
    var listCountriesSpec = new ListCountriesSpec(3, 5);

    // Assert
    var querySpec = listCountriesSpec.Query.Specification;
    querySpec.Skip.Should().Be(10);
    querySpec.Take.Should().Be(5);
  }
}
