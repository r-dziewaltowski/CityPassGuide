﻿using CityPassGuide.UseCases.Countries;
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
        var response = await Client.GetAndDeserializeAsync<IEnumerable<CountryDto>>(request);

        // Assert
        response.Should().HaveCount(3);
    }

    [Fact]
    public async Task Endpoint_ShouldReturnOnePage()
    {
        // Arrange
        var request = CreateRequest()
            .AddParameter(ListCountriesRequest.PageNumberParamName, 2)
            .AddParameter(ListCountriesRequest.PageSizeParamName, 1);

        // Act
        var response = await Client.GetAndDeserializeAsync<IEnumerable<CountryDto>>(request);

        // Assert
        response.Should().ContainSingle();
        response.First().Id.Should().Be(2);
    }

    [Fact]
    public async Task Endpoint_ShouldReturnPaginationMetadataHeader()
    {
        // Act
        var response = await Client.GetAsync(ListCountriesRequest.Route);

        // Assert
        response.Headers.Should().ContainKey(PaginationMetadata.PaginationMetadataHeader);
    }

    [Fact]
    public async Task Endpoint_ShouldReturnFilteredCountry()
    {
        // Arrange
        var request = CreateRequest()
            .AddParameter(ListCountriesRequest.NameParamName, "Poland");

        // Act
        var response = await Client.GetAndDeserializeAsync<IEnumerable<CountryDto>>(request);

        // Assert
        response.Should().ContainSingle();
        response.First().Id.Should().Be(3);
    }

    [Fact]
    public async Task Endpoint_ShouldReturnSearchedCountry()
    {
        // Arrange
        var request = CreateRequest()
            .AddParameter(ListCountriesRequest.SearchQueryParamName, "United");

        // Act
        var response = await Client.GetAndDeserializeAsync<IEnumerable<CountryDto>>(request);

        // Assert
        response.Should().ContainSingle();
        response.First().Id.Should().Be(1);
    }

    private static RestRequest CreateRequest()
    {
        return new RestRequest(ListCountriesRequest.Route);
    }
}
