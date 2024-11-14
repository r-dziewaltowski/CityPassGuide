using Xunit;
using FluentAssertions;
using CityPassGuide.Web.Countries;

namespace CityPassGuide.UnitTests.Web.Countries.ListCountries;

public class ListCountriesValidatorTests
{
  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void Validate_ShouldFail_WhenPageNumberLessThanOne(int pageNumber)
  {
    // Arrange
    var request = new ListCountriesRequest
    {
      PageNumber = pageNumber
    };
    var validator = new ListCountriesValidator();

    // Act
    var result = validator.Validate(request);

    // Assert
    result.IsValid.Should().BeFalse();
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void Validate_ShouldFail_WhenPageSizeLessThanOne(int pageSize)
  {
    // Arrange
    var request = new ListCountriesRequest
    {
      PageSize = pageSize
    };
    var validator = new ListCountriesValidator();

    // Act
    var result = validator.Validate(request);

    // Assert
    result.IsValid.Should().BeFalse();
  }
}
