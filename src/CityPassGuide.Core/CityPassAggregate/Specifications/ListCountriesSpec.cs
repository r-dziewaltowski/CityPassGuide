using Ardalis.Specification;

namespace CityPassGuide.Core.CityPassAggregate.Specifications;

public class ListCountriesSpec : Specification<Country>
{
    public ListCountriesSpec(int pageNumber, int pageSize, string? name, string? searchQuery)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Query.Where(country => country.Name == name.Trim());
        }

        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            Query.Where(country => country.Name.Contains(searchQuery.Trim()));
        }

        Query
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize);
    }
}
