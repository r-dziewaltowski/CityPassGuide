using Ardalis.Result;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.List;
using FastEndpoints;
using MediatR;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// List all Countries
/// </summary>
/// <remarks>
/// List all countries - returns a CountryListResponse containing the countries.
/// </remarks>
public class ListCountriesEndpoint(IMediator mediator) : Endpoint<ListCountriesRequest, ListCountriesResponse>
{
  private const int DefaultPageNumber = 1;
  private const int DefaultPageSize = 10;
  private const int MaxPageSize = 20;

  private readonly IMediator _mediator = mediator;

  public override void Configure()
  {
    Get(ListCountriesRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(ListCountriesRequest request, CancellationToken cancellationToken)
  {
    var pageNumber = request.PageNumber ?? DefaultPageNumber;
    var pageSize = Math.Min(request.PageSize ?? DefaultPageSize, MaxPageSize);

    Result<IEnumerable<CountryDto>> result = await _mediator.Send(
      new ListCountriesQuery(pageNumber, pageSize), 
      cancellationToken);

    if (result.IsSuccess)
    {
      Response = new ListCountriesResponse
      {
        Countries = result.Value.ToList()
      };
    }
  }
}
