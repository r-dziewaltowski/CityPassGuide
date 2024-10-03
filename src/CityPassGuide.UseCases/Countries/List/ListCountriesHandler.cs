using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityCardAggregate;
using CityPassGuide.Core.CityCardAggregate.Specifications;

namespace CityPassGuide.UseCases.Countries.List;

public class ListCountriesHandler(IReadRepository<Country> _repository, IMapper mapper)
  : IQueryHandler<ListCountriesQuery, Result<IEnumerable<CountryDto>>>
{
  public async Task<Result<IEnumerable<CountryDto>>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
  {
    var spec = new ListCountriesSpec(request.PageNumber, request.PageSize);
    var result = await _repository.ListAsync(spec, cancellationToken);

    return Result.Success(mapper.Map<IEnumerable<CountryDto>>(result));
  }
}
