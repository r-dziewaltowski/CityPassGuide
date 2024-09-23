using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class City : EntityBase
{
  public string Name { get; private set; }
  public int CountryId { get; private set; }
  public decimal DailyTransportCost { get; private set; }

  private readonly List<CityCard> _cityCards = [];
  public IEnumerable<CityCard> CityCards => _cityCards.AsReadOnly();

  private readonly List<Attraction> _attractions = [];
  public IEnumerable<Attraction> Attractions => _attractions.AsReadOnly();

  public City(string name,
              int countryId,
              decimal dailyTransportCost,
              IEnumerable<CityCard> cityCards,
              IEnumerable<Attraction> attractions)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    CountryId = Guard.Against.NegativeOrZero(countryId);
    DailyTransportCost = Guard.Against.Negative(dailyTransportCost);
    _cityCards = cityCards.ToList();
    _attractions = attractions.ToList();
  }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
  private City() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
