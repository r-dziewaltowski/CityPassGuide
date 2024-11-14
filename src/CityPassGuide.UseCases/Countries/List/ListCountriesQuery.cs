using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Countries.List;

public record ListCountriesQuery(int PageNumber, int PageSize) 
  : IQuery<Result<IEnumerable<CountryDto>>>;
