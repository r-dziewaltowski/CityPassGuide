using Ardalis.HttpClientTestExtensions;
using CityPassGuide.Web.Countries;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class ListCountriesTests(CustomWebApplicationFactory<Program> factory) 
  : TestsBase, IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsAllCountries()
  {
    // Arrange
    CreateAndSeedDatabase(factory);

    // Act
    var result = await _client.GetAndDeserializeAsync<ListCountriesResponse>(ListCountries.Route);

    // Assert
    result.Countries.Should().HaveCount(3);
  }
}
