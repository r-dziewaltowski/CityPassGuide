using System.Text.Json;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.List;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// List countries
/// </summary>
/// <remarks>
/// Returns a single page of countries.
/// </remarks>
public class ListCountriesEndpoint(IMediator mediator)
    : Endpoint<ListCountriesRequest, Results<Ok<IEnumerable<CountryDto>>, InternalServerError>>
{
    private readonly IMediator _mediator = mediator;

    public override void Configure()
    {
        Get(ListCountriesRequest.Route);
        AllowAnonymous();
        Description(b => b.ProducesProblemFE<InternalErrorResponse>(500));
    }

    public override async Task<Results<Ok<IEnumerable<CountryDto>>, InternalServerError>> ExecuteAsync(
        ListCountriesRequest request, CancellationToken cancellationToken)
    {
        var pageNumber = request.AdjustedPageNumber;
        var pageSize = request.AdjustedPageSize;
        var query = new ListCountriesQuery(pageNumber, pageSize, request.Name);

        var (result, totalItemCount) = await _mediator.Send(query, cancellationToken);

        if (!result.IsSuccess)
        {
            return TypedResults.InternalServerError();
        }

        AddPaginationMetadataHeader(pageNumber, pageSize, totalItemCount);
        return TypedResults.Ok(result.Value);
    }

    private void AddPaginationMetadataHeader(int pageNumber, int pageSize, int totalItemCount)
    {
        var paginationMetadata = new PaginationMetadata(pageNumber, pageSize, totalItemCount);
        HttpContext.Response.Headers.Append(PaginationMetadata.PaginationMetadataHeader,
            JsonSerializer.Serialize(paginationMetadata));
    }
}
