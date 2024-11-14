using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.UseCases.Countries.Get;

public class GetCountryByIdHandler(IReadRepository<Country> repository, IMapper mapper)
  : IQueryHandler<GetCountryByIdQuery, Result<CountryDto>>
{
  private readonly IReadRepository<Country> _repository = repository;
  private readonly IMapper _mapper = mapper;

  public async Task<Result<CountryDto>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (result == null) return Result.NotFound();

    return _mapper.Map<CountryDto>(result);
  }
}
