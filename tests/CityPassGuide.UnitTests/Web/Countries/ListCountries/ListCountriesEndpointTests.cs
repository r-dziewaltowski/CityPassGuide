using Xunit;
using NSubstitute;
using FluentAssertions;
using MediatR;
using CityPassGuide.Web.Countries;
using CityPassGuide.UseCases.Countries;
using System.Net;
using FastEndpoints;
using CityPassGuide.UseCases.Countries.List;
using CityPassGuide.Web;

namespace CityPassGuide.UnitTests.Web.Countries.ListCountries;

public class ListCountriesEndpointTests
{
  private readonly IMediator _mediator = Substitute.For<IMediator>();

  [Fact]
  public async Task HandleAsync_ShouldSendQueryViaMediatorWithCorrectParams()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new ListCountriesRequest();
    var cancellationToken = new CancellationToken();
    var result = new List<CountryDto>();
    _mediator.Send(Arg.Any<ListCountriesQuery>(), cancellationToken)
      .Returns((result, 0));

    // Act
    await endpoint.HandleAsync(request, cancellationToken);

    // Assert
    await _mediator.Received()
      .Send(Arg.Is<ListCountriesQuery>(query => 
          query.PageNumber == request.GetAdjustedPageNumber() &&
          query.PageSize == request.GetAdjustedPageSize()),
        cancellationToken);
  }

  [Fact]
  public async Task HandleAsync_ShouldReturnCorrectResponse_WhenSuccessfulResult()
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
    await endpoint.HandleAsync(request, default);

    // Assert
    endpoint.HttpContext.Response.StatusCode.Should().Be((int)HttpStatusCode.OK);
    endpoint.Response.Should().HaveCount(2);
  }

  [Fact]
  public async Task HandleAsync_ShouldReturnCorrectPaginationMetadataHeader_WhenSuccessfulResult()
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
    await endpoint.HandleAsync(request, default);

    // Assert
    endpoint.HttpContext.Response.Headers.Should().Contain(PaginationMetadata.PaginationMetadataHeader,
      "{\"PageNumber\":1,\"PageSize\":2,\"TotalItemCount\":3,\"TotalPageCount\":2}");
  }

  private ListCountriesEndpoint CreateEndpoint()
  {
    return Factory.Create<ListCountriesEndpoint>(_mediator);
  }
}
