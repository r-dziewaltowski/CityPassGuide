using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityCardAggregate;

namespace CityPassGuide.UseCases.Countries.Get;

public class GetCountryHandler(IReadRepository<Country> _repository, IMapper mapper)
  : IQueryHandler<GetCountryQuery, Result<CountryDto>>
{
  public async Task<Result<CountryDto>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (result == null) return Result.NotFound();

    return mapper.Map<CountryDto>(result);
  }
}
