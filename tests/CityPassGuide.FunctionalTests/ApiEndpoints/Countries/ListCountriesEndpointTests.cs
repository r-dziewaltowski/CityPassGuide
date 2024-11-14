using CityPassGuide.Web.Countries;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class ListCountriesEndpointTests(CustomWebApplicationFactory<Program> factory) 
  : TestsBase(factory), IClassFixture<CustomWebApplicationFactory<Program>>
{
  [Fact]
  public async Task ReturnsAllCountries()
  {
    // Arrange
    var request = CreateRequest();

    // Act
    var result = await Client.GetAndDeserializeAsync<ListCountriesResponse>(request);

    // Assert
    result.Countries.Should().HaveCount(3);
  }

  private static RestRequest CreateRequest()
  {
    return new RestRequest(ListCountriesRequest.Route);
  }
}
