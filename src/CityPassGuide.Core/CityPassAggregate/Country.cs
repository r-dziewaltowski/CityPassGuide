using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class Country(string name) : EntityBase
{
  public string Name { get; private set; } = name;

  private readonly List<City> _cities = [];
  public IEnumerable<City> Cities => _cities.AsReadOnly();
}
