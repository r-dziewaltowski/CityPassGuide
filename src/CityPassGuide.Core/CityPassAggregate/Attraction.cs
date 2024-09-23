using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class Attraction(string name, int cityId, decimal price) : EntityBase
{
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public int CityId { get; private set; } = Guard.Against.NegativeOrZero(cityId);
  public decimal Price { get; private set; } = Guard.Against.Negative(price);
}
