using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityCardAggregate;

public class Country(string name) : EntityBase, IAggregateRoot
{
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));

  private readonly List<City> _cities = [];

  public IEnumerable<City> Cities => _cities.AsReadOnly();
}
