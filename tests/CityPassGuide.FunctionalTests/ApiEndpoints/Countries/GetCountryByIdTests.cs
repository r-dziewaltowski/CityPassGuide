using CityPassGuide.UseCases.Countries;
using CityPassGuide.Web.Countries;
using FluentAssertions;
using RestSharp;
using Xunit;

namespace CityPassGuide.FunctionalTests.ApiEndpoints.Countries;

public class GetCountryByIdTests(CustomWebApplicationFactory<Program> factory) 
  : TestsBase, IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ValidatesId()
  {
    // Arrange
    var request = CreateRequest(0);

    // Act
    var act = () => _client.GetAndDeserializeAsync<CountryDto>(request);

    // Assert
    await act.Should().ThrowAsync<HttpRequestException>();
  }

  [Fact]
  public async Task ReturnsSeedCountryGivenId1()
  {
    // Arrange
    CreateAndSeedDatabase(factory);
    var request = CreateRequest(1);

    // Act
    var result = await _client.GetAndDeserializeAsync<CountryDto>(request);

    // Assert
    result.Id.Should().Be(1);
    result.Name.Should().Be("United Kingdom");
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    // Arrange
    CreateAndSeedDatabase(factory);
    var request = CreateRequest(1000);

    // Act + Assert
    await _client.GetAndEnsureNotFoundAsync(request);
  }

  private static RestRequest CreateRequest(int countryId)
  {
    return new RestRequest(GetCountryByIdRequest.Route)
      .AddUrlSegment(GetCountryByIdRequest.CountryIdParamName, countryId);
  }
}
