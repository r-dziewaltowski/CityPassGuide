using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Countries.List;

public record ListCountriesQuery(int PageNumber = 1, int PageSize = 10) 
  : IQuery<Result<IEnumerable<CountryDto>>>;
