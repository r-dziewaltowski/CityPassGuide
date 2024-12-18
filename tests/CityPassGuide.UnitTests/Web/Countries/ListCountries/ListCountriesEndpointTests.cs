﻿using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.List;
using CityPassGuide.Web;
using CityPassGuide.Web.Countries;
using FastEndpoints;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;

namespace CityPassGuide.UnitTests.Web.Countries.ListCountries;

public class ListCountriesEndpointTests
{
    private readonly IMediator _mediator = Substitute.For<IMediator>();

    [Fact]
    public async Task ExecuteAsync_ShouldSendQueryViaMediatorWithCorrectParams()
    {
        // Arrange
        var endpoint = CreateEndpoint();
        var request = new ListCountriesRequest()
        {
            PageNumber = 1,
            PageSize = 1,
            Name = "TestName",
            SearchQuery = "TestSearchQuery"
        };
        var cancellationToken = new CancellationToken();
        var result = new List<CountryDto>();
        _mediator.Send(Arg.Any<ListCountriesQuery>(), cancellationToken)
            .Returns((result, 0));

        // Act
        await endpoint.ExecuteAsync(request, cancellationToken);

        // Assert
        await _mediator.Received()
            .Send(Arg.Is<ListCountriesQuery>(query =>
                    query.PageNumber == request.PageNumber &&
                    query.PageSize == request.PageSize &&
                    query.Name == request.Name &&
                    query.SearchQuery == request.SearchQuery),
                cancellationToken);
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnCorrectResponse_WhenSuccessfulResult()
    {
        // Arrange
        var endpoint = CreateEndpoint();
        var request = new ListCountriesRequest();
        var result = new List<CountryDto>
        {
            new(1, "test_name1"),
            new(2, "test_name2")
        };
        _mediator.Send(Arg.Any<ListCountriesQuery>(), Arg.Any<CancellationToken>())
            .Returns((result, 2));

        // Act
        var response = await endpoint.ExecuteAsync(request, default);

        // Assert
        response.Result.Should().BeOfType<Ok<IEnumerable<CountryDto>>>();
        response.Result.As<Ok<IEnumerable<CountryDto>>>().Value.Should().Equal(result);
    }

    [Fact]
    public async Task ExecuteAsync_ShouldReturnCorrectPaginationMetadataHeader_WhenSuccessfulResult()
    {
        // Arrange
        var endpoint = CreateEndpoint();
        var request = new ListCountriesRequest()
        {
            PageNumber = 1,
            PageSize = 2
        };
        var result = new List<CountryDto>
        {
            new(1, "test_name1"),
            new(2, "test_name2"),
            new(3, "test_name3")
        };
        _mediator.Send(Arg.Any<ListCountriesQuery>(), Arg.Any<CancellationToken>())
            .Returns((result, 3));

        // Act
        await endpoint.ExecuteAsync(request, default);

        // Assert
        endpoint.HttpContext.Response.Headers.Should().Contain(PaginationMetadata.PaginationMetadataHeader,
            "{\"PageNumber\":1,\"PageSize\":2,\"TotalItemCount\":3,\"TotalPageCount\":2}");
    }

    private ListCountriesEndpoint CreateEndpoint()
    {
        return Factory.Create<ListCountriesEndpoint>(_mediator);
    }
}
