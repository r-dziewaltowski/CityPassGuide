using Ardalis.Result;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.Get;
using CityPassGuide.Web.Countries;
using FastEndpoints;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Xunit;

namespace CityPassGuide.UnitTests.Web.Countries.GetCountryById;

public class GetCountryByIdEndpointTests
{
  private readonly IMediator _mediator = Substitute.For<IMediator>();

  [Fact]
  public async Task ExecuteAsync_ShouldSendQueryViaMediatorWithCorrectParams()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new GetCountryByIdRequest
    {
      CountryId = 1
    };
    var result = new CountryDto(1, "TestName");
    var cancellationToken = new CancellationToken();
    _mediator.Send(Arg.Any<GetCountryByIdQuery>(), cancellationToken)
      .Returns(result);

    // Act
    await endpoint.ExecuteAsync(request, cancellationToken);

    // Assert
    await _mediator.Received()
      .Send(Arg.Is<GetCountryByIdQuery>(query => query.CountryId == request.CountryId), cancellationToken);
  }

  [Fact]
  public async Task ExecuteAsync_ShouldReturnNotFound_WhenNoCountryFound()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new GetCountryByIdRequest();
    _mediator.Send(Arg.Any<GetCountryByIdQuery>(), Arg.Any<CancellationToken>())
      .Returns(Result<CountryDto>.NotFound());

    // Act
    var response = await endpoint.ExecuteAsync(request, default);

    // Assert
    response.Result.Should().BeOfType<NotFound>();
  }

  [Fact]
  public async Task ExecuteAsync_ShouldReturnCorrectResponse_WhenSuccessfulResult()
  {
    // Arrange
    var endpoint = CreateEndpoint();
    var request = new GetCountryByIdRequest();
    var result = new CountryDto(1, "TestName");
    _mediator.Send(Arg.Any<GetCountryByIdQuery>(), Arg.Any<CancellationToken>())
      .Returns(result);

    // Act
    var response = await endpoint.ExecuteAsync(request, default);

    // Assert
    response.Result.Should().BeOfType<Ok<CountryDto>>();
    response.Result.As<Ok<CountryDto>>().Value.Should().Be(result);
  }

  private GetCountryByIdEndpoint CreateEndpoint()
  {
    return Factory.Create<GetCountryByIdEndpoint>(_mediator);
  }
}
