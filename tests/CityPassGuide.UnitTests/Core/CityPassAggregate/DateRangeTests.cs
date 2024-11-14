using Xunit;
using CityPassGuide.Core.CityPassAggregate;
using FluentAssertions;

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
    dateRange.StartDate.Should().Be(startDate);
    dateRange.EndDate.Should().Be(endDate);
  }

  [Fact]
  public void Constructor_ShouldSetEndDateToMaxValue_WhenEndDateNotProvided()
  {
    // Arrange
    var startDate = new DateOnly(2024, 9, 23);

    // Act
    var dateRange = new DateRange(startDate, null);

    // Assert
    dateRange.EndDate.Should().Be(DateOnly.MaxValue);
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenEndDateIsBeforeStartDate()
  {
    // Arrange
    var startDate = new DateOnly(2024, 9, 23);
    var endDate = new DateOnly(2024, 9, 22);

    // Act
    var act = () => new DateRange(startDate, endDate);

    // Assert
    act.Should().Throw<ArgumentException>();
  }
}
