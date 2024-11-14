using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityPassAggregate;
using CityPassGuide.Core.CityPassAggregate.Specifications;

namespace CityPassGuide.UseCases.Countries.List;

public class ListCountriesHandler(IReadRepository<Country> repository, IMapper mapper)
  : IQueryHandler<ListCountriesQuery, Result<IEnumerable<CountryDto>>>
{
  private readonly IReadRepository<Country> _repository = repository;
  private readonly IMapper _mapper = mapper;

  public async Task<Result<IEnumerable<CountryDto>>> Handle(ListCountriesQuery request, CancellationToken cancellationToken)
  {
    var spec = new ListCountriesSpec(request.PageNumber, request.PageSize);
    var result = await _repository.ListAsync(spec, cancellationToken);

    return Result.Success(_mapper.Map<IEnumerable<CountryDto>>(result));
  }
}
