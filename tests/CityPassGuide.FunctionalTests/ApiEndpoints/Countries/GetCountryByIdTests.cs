using Ardalis.HttpClientTestExtensions;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.Web.Countries;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class GetCountryByIdTests(CustomWebApplicationFactory<Program> factory) 
  : TestsBase, IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedCountryGivenId1()
  {
    // Arrange
    CreateAndSeedDatabase(factory);
    var route = GetCountryByIdRequest.BuildRoute(1);

    // Act
    var result = await _client.GetAndDeserializeAsync<CountryDto>(route);

    // Assert
    result.Id.Should().Be(1);
    result.Name.Should().Be("United Kingdom");
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    // Arrange
    CreateAndSeedDatabase(factory);
    var route = GetCountryByIdRequest.BuildRoute(1000);

    // Act + Assert
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
