using Ardalis.Result;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.Get;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// Get a country by ID
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching country DTO.
/// </remarks>
public class GetCountryByIdEndpoint(IMediator mediator)
  : Endpoint<GetCountryByIdRequest, Results<Ok<CountryDto>, NotFound, InternalServerError>>
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

  public override async Task<Results<Ok<CountryDto>, NotFound, InternalServerError>> ExecuteAsync(
    GetCountryByIdRequest request, CancellationToken cancellationToken)
  {
    var query = new GetCountryByIdQuery(request.CountryId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      return TypedResults.NotFound();
    }

    if (!result.IsSuccess)
    {
      return TypedResults.InternalServerError();
    }

    return TypedResults.Ok(result.Value);
  }
}
