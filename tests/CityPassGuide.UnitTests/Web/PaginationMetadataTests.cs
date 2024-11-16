using Xunit;
using FluentAssertions;
using CityPassGuide.Web;

namespace CityPassGuide.UnitTests.Web;

public class PaginationMetadataTests
{
  [Theory]
  [InlineData(1, 5, 12, 3)]
  [InlineData(1, 5, 10, 2)]
  [InlineData(1, 5, 3, 1)]
  [InlineData(1, 5, 0, 0)]
  public void TotalPageCount_ShouldReturnCorrectValue(
    int pageNumber, int pageSize, int totalItemCount, int expectedTotalPageCount)
  {
    // Arrange
    var paginationMetadata = new PaginationMetadata(pageNumber, pageSize, totalItemCount);

    // Act
    var totalPageCount = paginationMetadata.TotalPageCount;

    // Assert
    totalPageCount.Should().Be(expectedTotalPageCount);
  }
}
