using Ardalis.Result;
using Ardalis.SharedKernel;
using CityPassGuide.Core.CityCardAggregate;

namespace CityPassGuide.UseCases.Countries.List;

public class ListCountriesHandler(IReadRepository<Country> _repository)
  : IQueryHandler<ListCountriesQuery, Result<IEnumerable<CountryDto>>>
{
  public async Task<Result<IEnumerable<CountryDto>>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.ListAsync(cancellationToken);

    return Result.Success(result.Select(c => new CountryDto(c.Id, c.Name)));
  }
}
