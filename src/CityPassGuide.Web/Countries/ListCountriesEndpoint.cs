﻿using Ardalis.Result;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.List;
using FastEndpoints;
using MediatR;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// List countries
/// </summary>
/// <remarks>
/// Returns a single page of countries.
/// </remarks>
public class ListCountriesEndpoint(IMediator mediator) : Endpoint<ListCountriesRequest, IEnumerable<CountryDto>>
{
  private readonly IMediator _mediator = mediator;

  public override void Configure()
  {
    Get(ListCountriesRequest.Route);
    AllowAnonymous();
    Description(b => b
      .ProducesProblemFE<InternalErrorResponse>(500));
  }

  public override async Task HandleAsync(ListCountriesRequest request, CancellationToken cancellationToken)
  {
    var pageNumber = request.GetAdjustedPageNumber();
    var pageSize = request.GetAdjustedPageSize();
    var query = new ListCountriesQuery(pageNumber, pageSize);

    Result<IEnumerable<CountryDto>> result = await _mediator.Send(query, cancellationToken);

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
