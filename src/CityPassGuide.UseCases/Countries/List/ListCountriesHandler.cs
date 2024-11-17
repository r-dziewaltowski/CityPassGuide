using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityPassAggregate;
using CityPassGuide.Core.CityPassAggregate.Specifications;

namespace CityPassGuide.UseCases.Countries.List;

public class ListCountriesHandler(IReadRepository<Country> repository, IMapper mapper)
    : IQueryHandler<ListCountriesQuery, (Result<IEnumerable<CountryDto>>, int)>
{
    private readonly IReadRepository<Country> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<(Result<IEnumerable<CountryDto>>, int)> Handle(ListCountriesQuery query, CancellationToken cancellationToken)
    {
        var spec = new ListCountriesSpec(query.PageNumber, query.PageSize);
        var result = await _repository.ListAsync(spec, cancellationToken);
        var totalItemCount = await _repository.CountAsync(cancellationToken);

        return (Result.Success(_mapper.Map<IEnumerable<CountryDto>>(result)), totalItemCount);
    }
}
