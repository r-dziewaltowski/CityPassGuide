using Ardalis.GuardClauses;

namespace CityPassGuide.Core.CityPassAggregate;

public class City(string name, Country country, decimal dailyTransportCost)
{
  public string Name { get; private set; } = name;
  public Country Country { get; } = country;
  public decimal DailyTransportCost { get; private set; } = Guard.Against.Negative(dailyTransportCost);

  public void UpdateDailyTransportCost(decimal newDailyTransportCost)
  {
    DailyTransportCost = Guard.Against.Negative(newDailyTransportCost);
  }
}
