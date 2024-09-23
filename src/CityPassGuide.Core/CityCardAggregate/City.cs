using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityCardAggregate;

public class City(string name, int countryId, decimal dailyTransportCost) : EntityBase
{
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public int CountryId { get; private set; } = Guard.Against.NegativeOrZero(countryId);
  public decimal DailyTransportCost { get; private set; } = Guard.Against.Negative(dailyTransportCost);

  private readonly List<CityCard> _cityCards = [];
  public IEnumerable<CityCard> CityCards => _cityCards.AsReadOnly();

  private readonly List<Attraction> _attractions = [];
  public IEnumerable<Attraction> Attractions => _attractions.AsReadOnly();
}
