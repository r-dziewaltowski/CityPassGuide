using CityPassGuide.Core.CityCardAggregate.Specifications;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityCardAggregate.Specifications;

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
