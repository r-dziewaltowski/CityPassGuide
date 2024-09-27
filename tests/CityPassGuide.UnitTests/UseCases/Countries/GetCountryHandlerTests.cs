using Ardalis.SharedKernel;
using CityPassGuide.Core.CityCardAggregate;
using CityPassGuide.UseCases.Countries.Get;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Ardalis.Result;

namespace CityPassGuide.UnitTests.UseCases.Countries;

public class GetCountryHandlerTests
{
  private readonly IReadRepository<Country> _repository = Substitute.For<IReadRepository<Country>>();

  [Fact]
  public async Task Handle_ShouldCallGetByIdAsyncWithCorrectArguments()
  {
    // Arrange
    var handler = new GetCountryHandler(_repository);
    var request = new GetCountryQuery(1);
    var cancellationToken = new CancellationToken();

    // Act
    await handler.Handle(request, cancellationToken);

    // Assert
    await _repository.Received().GetByIdAsync(request.Id, cancellationToken);
  }

  [Fact]
  public async Task Handle_ShouldReturnNotFound_WhenNoResult()
  {
    // Arrange
    var handler = new GetCountryHandler(_repository);
    var request = new GetCountryQuery(1);
    _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
      .Returns((Country?)null);

    // Act
    var result = await handler.Handle(request, CancellationToken.None);

    // Assert
    result.Status.Should().Be(ResultStatus.NotFound);
  }

  [Fact]
  public async Task Handle_ShouldReturnDto_WhenResultFound()
  {
    // Arrange
    var handler = new GetCountryHandler(_repository);
    var country = new Country("test_name");
    var request = new GetCountryQuery(1);
    _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
      .Returns(country);

    // Act
    var result = await handler.Handle(request, CancellationToken.None);

    // Assert
    result.IsSuccess.Should().BeTrue();
    result.Value.Id.Should().Be(country.Id);
    result.Value.Name.Should().Be(country.Name);
  }
}
