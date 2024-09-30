using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityCardAggregate;

namespace CityPassGuide.UseCases.Countries.List;

public class ListCountriesHandler(IReadRepository<Country> _repository, IMapper mapper)
  : IQueryHandler<ListCountriesQuery, Result<IEnumerable<CountryDto>>>
{
  public async Task<Result<IEnumerable<CountryDto>>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.ListAsync(cancellationToken);

    return Result.Success(mapper.Map<IEnumerable<CountryDto>>(result));
  }
}
