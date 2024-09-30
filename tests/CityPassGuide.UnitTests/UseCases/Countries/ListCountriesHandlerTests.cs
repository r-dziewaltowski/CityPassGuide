using Ardalis.SharedKernel;
using CityPassGuide.Core.CityCardAggregate;
using FluentAssertions;
using NSubstitute;
using Xunit;
using CityPassGuide.UseCases.Countries.List;
using AutoMapper;
using CityPassGuide.UseCases.Countries;

namespace CityPassGuide.UnitTests.UseCases.Countries;

public class ListCountriesHandlerTests
{
  private readonly IReadRepository<Country> _repository = Substitute.For<IReadRepository<Country>>();
  private readonly IMapper _mapper = Substitute.For<IMapper>();

  [Fact]
  public async Task Handle_ShouldGetCountriesFromRepository()
  {
    // Arrange
    var handler = new ListCountriesHandler(_repository, _mapper);
    var request = new ListCountriesQuery(null, null);
    var cancellationToken = new CancellationToken();

    // Act
    await handler.Handle(request, cancellationToken);

    // Assert
    await _repository.Received().ListAsync(cancellationToken);
  }

  [Fact]
  public async Task Handle_ShouldMapEntitiesToDtos()
  {
    // Arrange
    var handler = new ListCountriesHandler(_repository, _mapper);
    var request = new ListCountriesQuery(null, null);
    var cancellationToken = new CancellationToken();
    var entities = new List<Country>();
    _repository.ListAsync(Arg.Any<CancellationToken>()).Returns(entities);

    // Act
    await handler.Handle(request, cancellationToken);

    // Assert
    _mapper.Received().Map<IEnumerable<CountryDto>>(entities);
  }

  [Fact]
  public async Task Handle_ShouldReturnExpectedResult()
  {
    // Arrange
    var handler = new ListCountriesHandler(_repository, _mapper);
    var request = new ListCountriesQuery(null, null);
    var dtos = new List<CountryDto>()
    {
      new(1, "test_name1"),
      new(2, "test_name2")
    };
    _mapper.Map<IEnumerable<CountryDto>>(Arg.Any<List<Country>>()).Returns(dtos);

    // Act
    var result = await handler.Handle(request, CancellationToken.None);

    // Assert
    result.IsSuccess.Should().BeTrue();
    result.Value.Should().HaveCount(2);
  }
}
