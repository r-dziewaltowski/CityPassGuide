using CityPassGuide.UseCases.Countries;
using CityPassGuide.Web;
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

  [Fact]
  public async Task Endpoint_ShouldReturnOnePage()
  {
    // Arrange
    var request = CreateRequest()
      .AddParameter(ListCountriesRequest.PageNumberParamName, 2)
      .AddParameter(ListCountriesRequest.PageSizeParamName, 1);

    // Act
    var result = await Client.GetAndDeserializeAsync<IEnumerable<CountryDto>>(request);

    // Assert
    result.Should().HaveCount(1);
    result.First().Id.Should().Be(2);
  }

  [Fact]
  public async Task Endpoint_ShouldReturnPaginationMetadataHeader()
  {
    // Act
    var result = await Client.GetAsync(ListCountriesRequest.Route);

    // Assert
    result.Headers.Should().ContainKey(PaginationMetadata.PaginationMetadataHeader);
  }

  private static RestRequest CreateRequest()
  {
    return new RestRequest(ListCountriesRequest.Route);
  }
}
