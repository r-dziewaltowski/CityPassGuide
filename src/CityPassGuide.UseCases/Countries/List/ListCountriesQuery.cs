using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Countries.List;

public record ListCountriesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<CountryDto>>>;
