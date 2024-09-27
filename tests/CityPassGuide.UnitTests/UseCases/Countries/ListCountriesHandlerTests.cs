using Ardalis.SharedKernel;
using CityPassGuide.Core.CityCardAggregate;
using FluentAssertions;
using NSubstitute;
using Xunit;
using CityPassGuide.UseCases.Countries.List;

namespace CityPassGuide.UnitTests.UseCases.Countries;

public class ListCountriesHandlerTests
{
  private readonly IReadRepository<Country> _repository = Substitute.For<IReadRepository<Country>>();

  [Fact]
  public async Task Handle_ShouldCallListAsyncWithCorrectArguments()
  {
    // Arrange
    var handler = new ListCountriesHandler(_repository);
    var request = new ListCountriesQuery(null, null);
    var cancellationToken = new CancellationToken();
    _repository.ListAsync(Arg.Any<CancellationToken>()).Returns([]);

    // Act
    await handler.Handle(request, cancellationToken);

    // Assert
    await _repository.Received().ListAsync(cancellationToken);
  }

  [Fact]
  public async Task Handle_ShouldReturnAllResults()
  {
    // Arrange
    var handler = new ListCountriesHandler(_repository);
    var request = new ListCountriesQuery(null, null);
    var country = new Country("test_name");
    const int CountriesCount = 8;
    var countries = new List<Country>(Enumerable.Repeat(country, CountriesCount));
    _repository.ListAsync(Arg.Any<CancellationToken>()).Returns(countries);

    // Act
    var result = await handler.Handle(request, CancellationToken.None);

    // Assert
    result.IsSuccess.Should().BeTrue();
    result.Value.Should().HaveCount(CountriesCount);
  }
}
