using AutoMapper;
using CityPassGuide.UseCases.Countries;
using FluentAssertions;
using Xunit;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.UnitTests.UseCases.Profiles;
public class CountryProfileTests
{
  private readonly IMapper _mapper = AutoMapperConfig.Initialize();

  [Fact]
  public void Map_ShouldCorrectlyMapCountryToCountryDto()
  {
    // Arrange
    var country = new Country("test_name") { Id = 1 };

    // Act
    var countryDto = _mapper.Map<CountryDto>(country);

    // Assert
    countryDto.Id.Should().Be(country.Id);
    countryDto.Name.Should().Be(country.Name);
  }
}
