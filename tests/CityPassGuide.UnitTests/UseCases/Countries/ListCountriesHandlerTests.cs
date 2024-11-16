using Ardalis.SharedKernel;
using FluentAssertions;
using NSubstitute;
using Xunit;
using CityPassGuide.UseCases.Countries.List;
using AutoMapper;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.Core.CityPassAggregate;
using CityPassGuide.Core.CityPassAggregate.Specifications;

namespace CityPassGuide.UnitTests.UseCases.Countries;

public class ListCountriesHandlerTests
{
  private readonly IReadRepository<Country> _repository = Substitute.For<IReadRepository<Country>>();
  private readonly IMapper _mapper = Substitute.For<IMapper>();

  [Fact]
  public async Task Handle_ShouldGetCountriesFromRepository()
  {
    // Arrange
    var handler = CreateHandler();
    var query = CreateQuery();
    var cancellationToken = new CancellationToken();

    // Act
    await handler.Handle(query, cancellationToken);

    // Assert
    await _repository.Received().ListAsync(
      Arg.Any<ListCountriesSpec>(),
      cancellationToken);
  }

  [Fact]
  public async Task Handle_ShouldGetTotalItemCountFromRepository()
  {
    // Arrange
    var handler = CreateHandler();
    var query = CreateQuery();
    var cancellationToken = new CancellationToken();

    // Act
    await handler.Handle(query, cancellationToken);

    // Assert
    await _repository.Received().CountAsync(cancellationToken);
  }

  [Fact]
  public async Task Handle_ShouldMapEntitiesToDtos()
  {
    // Arrange
    var handler = CreateHandler();
    var query = CreateQuery();
    var entities = new List<Country>();
    _repository.ListAsync(Arg.Any<ListCountriesSpec>(), Arg.Any<CancellationToken>())
      .Returns(entities);

    // Act
    await handler.Handle(query, default);

    // Assert
    _mapper.Received().Map<IEnumerable<CountryDto>>(entities);
  }

  [Fact]
  public async Task Handle_ShouldReturnExpectedResult()
  {
    // Arrange
    const int TotalItemCount = 10;
    var handler = CreateHandler();
    var query = CreateQuery();
    var dtos = new List<CountryDto>()
    {
      new(1, "test_name1"),
      new(2, "test_name2")
    };
    _repository.CountAsync(Arg.Any<CancellationToken>()).Returns(TotalItemCount);
    _mapper.Map<IEnumerable<CountryDto>>(Arg.Any<List<Country>>()).Returns(dtos);

    // Act
    var (result, totalItemCount) = await handler.Handle(query, default);

    // Assert
    result.IsSuccess.Should().BeTrue();
    result.Value.Should().HaveCount(2);
    totalItemCount.Should().Be(TotalItemCount);
  }

  private static ListCountriesQuery CreateQuery()
  {
    return new ListCountriesQuery(1, 5);
  }

  private ListCountriesHandler CreateHandler()
  {
    return new ListCountriesHandler(_repository, _mapper);
  }
}
