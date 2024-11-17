using FastEndpoints;
using FluentValidation;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class ListCountriesValidator : Validator<ListCountriesRequest>
{
    public ListCountriesValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}
