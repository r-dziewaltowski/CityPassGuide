using CityPassGuide.UseCases.Countries;
using CityPassGuide.Web.Countries;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class GetCountryByIdEndpointTests(CustomWebApplicationFactory<Program> factory)
  : TestsBase(factory), IClassFixture<CustomWebApplicationFactory<Program>>
{
  [Fact]
  public async Task Endpoint_ShouldReturnSeedCountryGivenId1()
  {
    // Arrange
    var request = CreateRequest(1);

    // Act
    var result = await Client.GetAndDeserializeAsync<CountryDto>(request);

    // Assert
    result.Id.Should().Be(1);
    result.Name.Should().Be("United Kingdom");
  }

  [Fact]
  public async Task Endpoint_ShouldReturnNotFoundGivenId1000()
  {
    // Arrange
    var request = CreateRequest(1000);

    // Act + Assert
    await Client.GetAndEnsureNotFoundAsync(request);
  }

  private static RestRequest CreateRequest(int countryId)
  {
    return new RestRequest(GetCountryByIdRequest.Route)
      .AddUrlSegment(GetCountryByIdRequest.CountryIdParamName, countryId);
  }
}
