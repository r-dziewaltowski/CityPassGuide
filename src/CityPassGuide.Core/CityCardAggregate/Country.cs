using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityCardAggregate;

public class Country : EntityBase
{
  public string Name { get; private set; }

  private readonly List<City> _cities = [];

  public IEnumerable<City> Cities => _cities.AsReadOnly();

  public Country(string name, IEnumerable<City> cities)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    _cities = cities.ToList();
  }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
  private Country() { } // EF required
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
