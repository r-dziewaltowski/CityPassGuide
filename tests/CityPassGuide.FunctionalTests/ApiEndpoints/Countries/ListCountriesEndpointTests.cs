using CityPassGuide.UseCases.Countries;
using CityPassGuide.Web.Countries;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class ListCountriesEndpointTests(CustomWebApplicationFactory<Program> factory) 
  : TestsBase(factory), IClassFixture<CustomWebApplicationFactory<Program>>
{
  [Fact]
  public async Task Endpoint_ShouldReturnAllCountries()
  {
    // Arrange
    var request = CreateRequest();

    // Act
    var result = await Client.GetAndDeserializeAsync<IEnumerable<CountryDto>>(request);

    // Assert
    result.Should().HaveCount(3);
  }

  private static RestRequest CreateRequest()
  {
    return new RestRequest(ListCountriesRequest.Route);
  }
}
