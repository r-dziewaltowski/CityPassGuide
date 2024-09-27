using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Countries.Get;

public record GetCountryQuery(int Id) : IQuery<Result<CountryDto>>;
