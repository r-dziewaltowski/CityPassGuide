using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.Core.CityPassAggregate;

public class City(string name, int countryId, decimal dailyTransportCost) : EntityBase
{
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public int CountryId { get; private set; } = Guard.Against.NegativeOrZero(countryId);
  public decimal DailyTransportCost { get; private set; } = Guard.Against.Negative(dailyTransportCost);

  private readonly List<CityPass> _cityPasses = [];
  public IEnumerable<CityPass> CityPasses => _cityPasses.AsReadOnly();

  private readonly List<Attraction> _attractions = [];
  public IEnumerable<Attraction> Attractions => _attractions.AsReadOnly();
}
