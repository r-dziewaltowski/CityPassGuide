using Xunit;
using Ardalis.Result;
using NSubstitute;
using FluentAssertions;
using MediatR;
using CityPassGuide.Web.Countries;
using CityPassGuide.UseCases.Countries.Get;
using CityPassGuide.UseCases.Countries;
using System.Net;
using FastEndpoints;

namespace CityPassGuide.UnitTests.Web.Countries;

public class GetCountryByIdEndpointTests
{
  private readonly IMediator _mediator = Substitute.For<IMediator>();

  [Fact]
  public async Task HandleAsync_ShouldSendQueryViaMediator()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new GetCountryByIdRequest
    {
      CountryId = 1
    };
    var cancellationToken = new CancellationToken();
    _mediator.Send(Arg.Any<GetCountryByIdQuery>(), cancellationToken)
      .Returns(new Result());

    // Act
    await endpoint.HandleAsync(request, cancellationToken);

    // Assert
    await _mediator.Received()
      .Send(Arg.Is<GetCountryByIdQuery>(query => query.Id == request.CountryId), cancellationToken);
  }

  [Fact]
  public async Task HandleAsync_ShouldReturnNotFound_WhenNoCountryFound()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new GetCountryByIdRequest();
    _mediator.Send(Arg.Any<GetCountryByIdQuery>(), Arg.Any<CancellationToken>())
      .Returns(Result<CountryDto>.NotFound());

    // Act
    await endpoint.HandleAsync(request, default);

    // Assert
    endpoint.HttpContext.Response.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
  }

  [Fact]
  public async Task HandleAsync_ShouldReturnExpectedResult_WhenCountryFound()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new GetCountryByIdRequest();
    var result = new CountryDto(1, "TestName");
    _mediator.Send(Arg.Any<GetCountryByIdQuery>(), Arg.Any<CancellationToken>())
      .Returns(result);

    // Act
    await endpoint.HandleAsync(request, default);

    // Assert
    endpoint.HttpContext.Response.StatusCode.Should().Be((int)HttpStatusCode.OK);
    endpoint.Response.Should().Be(result);
  }

  private GetCountryByIdEndpoint CreateEndpoint()
  {
    return Factory.Create<GetCountryByIdEndpoint>(_mediator);
  }
}
