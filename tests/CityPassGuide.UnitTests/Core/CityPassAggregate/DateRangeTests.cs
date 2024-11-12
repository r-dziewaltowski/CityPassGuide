using Xunit;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.UnitTests.Core.CityPassAggregate;
public class DateRangeTests
{
  [Fact]
  public void Constructor_ShouldSetDates()
  {
    // Arrange
    var startDate = new DateOnly(2024, 9, 23);
    var endDate = new DateOnly(2025, 10, 24);

    // Act
    var dateRange = new DateRange(startDate, endDate);

    // Assert
    Assert.Equal(startDate, dateRange.StartDate);
    Assert.Equal(endDate, dateRange.EndDate);
  }

  [Fact]
  public void Constructor_ShouldSetEndDateToMaxValue_WhenEndDateNotProvided()
  {
    // Arrange
    var startDate = new DateOnly(2024, 9, 23);

    // Act
    var dateRange = new DateRange(startDate, null);

    // Assert
    Assert.Equal(DateOnly.MaxValue, dateRange.EndDate);
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenEndDateIsBeforeStartDate()
  {
    // Arrange
    var startDate = new DateOnly(2024, 9, 23);
    var endDate = new DateOnly(2024, 9, 22);

    // Act + Assert
    Assert.Throws<ArgumentException>(() => new DateRange(startDate, endDate));
  }
}
