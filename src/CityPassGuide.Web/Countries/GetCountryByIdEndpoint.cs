﻿using Ardalis.Result;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.Get;
using FastEndpoints;
using MediatR;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// Get a country by ID
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching country DTO.
/// </remarks>
public class GetCountryByIdEndpoint(IMediator mediator) : Endpoint<GetCountryByIdRequest, CountryDto>
{
  private readonly IMediator _mediator = mediator;

  public override void Configure()
  {
    Get(GetCountryByIdRequest.Route);
    AllowAnonymous();
    Description(b => b
      .Produces(404)
      .ProducesProblemFE<InternalErrorResponse>(500));
  }

  public override async Task HandleAsync(GetCountryByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetCountryByIdQuery(request.CountryId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = result.Value;
    }
  }
}
