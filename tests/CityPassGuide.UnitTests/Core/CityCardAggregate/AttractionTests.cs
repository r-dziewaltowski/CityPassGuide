using CityPassGuide.Core.CityCardAggregate;
using Xunit;

namespace CityPassGuide.UnitTests.Core.CityCardAggregate;
public class AttractionTests
{
  private const string Name = "London Eye";
  private const int CityId = 1;
  private const int Price = 50;

  [Fact]
  public void Constructor_ShouldSetProperties()
  {
    // Act
    var attraction = new Attraction(Name, CityId, Price);

    // Assert
    Assert.Equal(Name, attraction.Name);
    Assert.Equal(CityId, attraction.CityId);
    Assert.Equal(Price, attraction.Price);
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenNameEmpty()
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new Attraction("", CityId, Price));
  }

  [Theory]
  [InlineData(-1)]
  [InlineData(0)]
  public void Constructor_ShouldThrow_WhenCityIdIsIncorrect(int cityId)
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new Attraction(Name, cityId, Price));
  }

  [Fact]
  public void Constructor_ShouldThrow_WhenPriceIsNegative()
  {
    // Act + Assert
    Assert.Throws<ArgumentException>(() => new Attraction(Name, CityId, -1));
  }
}
