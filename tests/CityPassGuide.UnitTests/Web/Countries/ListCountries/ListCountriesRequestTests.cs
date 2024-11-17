using CityPassGuide.Web.Countries;
using FluentAssertions;
using Xunit;

namespace CityPassGuide.UnitTests.Web.Countries.ListCountries;

public class ListCountriesRequestTests
{
    [Fact]
    public void GetAdjustedPageNumber_ShouldReturnProvidedPageNumber()
    {
        // Arrange
        var providedPageNumber = ListCountriesRequest.DefaultPageNumber + 1;
        var request = new ListCountriesRequest()
        {
            PageNumber = providedPageNumber
        };

        // Act
        var pageNumber = request.AdjustedPageNumber;

        // Assert
        pageNumber.Should().Be(providedPageNumber);
    }

    [Fact]
    public void GetAdjustedPageNumber_ShouldReturnDefaultPageNumber_WhenNotProvided()
    {
        // Arrange
        var request = new ListCountriesRequest();

        // Act
        var pageNumber = request.AdjustedPageNumber;

        // Assert
        pageNumber.Should().Be(ListCountriesRequest.DefaultPageNumber);
    }

    [Fact]
    public void GetAdjustedPageSize_ShouldReturnProvidedPageSize()
    {
        // Arrange
        var providedPageSize = ListCountriesRequest.DefaultPageSize - 1;
        var request = new ListCountriesRequest()
        {
            PageSize = providedPageSize
        };

        // Act
        var pageNumber = request.AdjustedPageSize;

        // Assert
        pageNumber.Should().Be(providedPageSize);
    }

    [Fact]
    public void GetAdjustedPageSize_ShouldReturnDefaultPageSize_WhenNotProvided()
    {
        // Arrange
        var request = new ListCountriesRequest();

        // Act
        var pageNumber = request.AdjustedPageSize;

        // Assert
        pageNumber.Should().Be(ListCountriesRequest.DefaultPageSize);
    }

    [Fact]
    public void GetAdjustedPageSize_ShouldReturnMaxPageSize_WhenProvidedTooHigh()
    {
        // Arrange
        var providedPageSize = ListCountriesRequest.MaxPageSize + 1;
        var request = new ListCountriesRequest()
        {
            PageSize = providedPageSize
        };

        // Act
        var pageNumber = request.AdjustedPageSize;

        // Assert
        pageNumber.Should().Be(ListCountriesRequest.MaxPageSize);
    }
}
