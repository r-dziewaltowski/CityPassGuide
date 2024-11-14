using Xunit;
using FluentAssertions;
using CityPassGuide.Web.Countries;

namespace CityPassGuide.UnitTests.Web.Countries.GetCountryById;

public class GetCountryByIdValidatorTests
{
  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void Validate_ShouldFail_WhenCountryIdLessThanOne(int countryId)
  {
    // Arrange
    var request = new GetCountryByIdRequest
    {
      CountryId = countryId
    };
    var validator = new GetCountryByIdValidator();

    // Act
    var result = validator.Validate(request);

    // Assert
    result.IsValid.Should().BeFalse();
  }
}
