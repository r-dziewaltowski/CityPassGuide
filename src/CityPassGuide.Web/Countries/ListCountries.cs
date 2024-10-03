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
public class ListCountries(IMediator _mediator) : EndpointWithoutRequest<ListCountriesResponse>
{
  public const string Route = "/Countries";

  public override void Configure()
  {
    Get(Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<CountryDto>> result = await _mediator.Send(
      new ListCountriesQuery(), 
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
