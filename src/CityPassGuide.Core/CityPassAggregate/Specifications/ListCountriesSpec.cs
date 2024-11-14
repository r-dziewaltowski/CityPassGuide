using Ardalis.Specification;

namespace CityPassGuide.Core.CityPassAggregate.Specifications;

public class ListCountriesSpec : Specification<Country>
{
  public ListCountriesSpec(int pageNumber, int pageSize)
  {
    Query
        .Skip(pageSize * (pageNumber - 1))
        .Take(pageSize);
  }
}
