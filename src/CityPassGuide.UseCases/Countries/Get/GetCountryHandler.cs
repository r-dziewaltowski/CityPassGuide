using Ardalis.Result;
using Ardalis.SharedKernel;
using CityPassGuide.Core.CityCardAggregate;

namespace CityPassGuide.UseCases.Countries.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetCountryHandler(IReadRepository<Country> _repository)
  : IQueryHandler<GetCountryQuery, Result<CountryDto>>
{
  public async Task<Result<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (result == null) return Result.NotFound();

    return new CountryDto(result.Id, result.Name);
  }
}
