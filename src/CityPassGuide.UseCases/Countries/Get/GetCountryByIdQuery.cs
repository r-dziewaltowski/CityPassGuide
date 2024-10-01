using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Countries.Get;

public record GetCountryByIdQuery(int Id) : IQuery<Result<CountryDto>>;
