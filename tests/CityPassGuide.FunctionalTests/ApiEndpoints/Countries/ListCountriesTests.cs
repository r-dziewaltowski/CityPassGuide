using CityPassGuide.Web.Countries;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class ListCountriesTests(CustomWebApplicationFactory<Program> factory) 
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

  [Fact]
  public async Task ReturnsOnePage()
  {
    // Arrange
    var request = CreateRequest()
      .AddParameter(ListCountriesRequest.PageNumberParamName, 2)
      .AddParameter(ListCountriesRequest.PageSizeParamName, 1);

    // Act
    var result = await Client.GetAndDeserializeAsync<ListCountriesResponse>(request);

    // Assert
    result.Countries.Should().HaveCount(1);
    result.Countries[0].Id.Should().Be(2);
  }

  private static RestRequest CreateRequest()
  {
    return new RestRequest(ListCountriesRequest.Route);
  }
}
