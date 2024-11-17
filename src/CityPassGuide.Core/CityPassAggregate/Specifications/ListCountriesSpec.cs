using Ardalis.Specification;

namespace CityPassGuide.Core.CityPassAggregate.Specifications;

public class ListCountriesSpec : Specification<Country>
{
    public ListCountriesSpec(int pageNumber, int pageSize, string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Query.Where(country => country.Name == name.Trim());
        }

        Query
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);
    }
}
