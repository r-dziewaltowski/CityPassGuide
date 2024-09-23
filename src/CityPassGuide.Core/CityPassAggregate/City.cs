using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class City : EntityBase
{
  public City(string name, int countryId, decimal dailyTransportCost)
  {
    Name = name;
    CountryId = countryId;
    DailyTransportCost = Guard.Against.Negative(dailyTransportCost);
  }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
  private City() { } // EF required
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

  public string Name { get; private set; }
  //public Country Country { get; } = country;
  public int CountryId { get; private set; }
  public decimal DailyTransportCost { get; private set; }

  public void UpdateDailyTransportCost(decimal newDailyTransportCost)
  {
    DailyTransportCost = Guard.Against.Negative(newDailyTransportCost);
  }
}
