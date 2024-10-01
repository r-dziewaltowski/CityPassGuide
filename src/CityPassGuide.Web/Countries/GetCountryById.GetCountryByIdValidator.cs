using FastEndpoints;
using FluentValidation;

namespace CityPassGuide.Web.Countries;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetCountryByIdValidator : Validator<GetCountryByIdRequest>
{
  public GetCountryByIdValidator()
  {
    RuleFor(x => x.CountryId)
      .GreaterThan(0);
  }
}
