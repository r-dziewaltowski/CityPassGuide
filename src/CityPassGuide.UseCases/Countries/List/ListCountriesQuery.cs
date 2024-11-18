using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Countries.List;

public record ListCountriesQuery(int PageNumber, int PageSize, string? Name, string? SearchQuery) 
    : IQuery<(Result<IEnumerable<CountryDto>>, int)>;
