namespace CityPassGuide.Web.Countries;

public class GetCountryByIdRequest
{
  public const string Route = $"{EndpointConstants.ApiRoot}/countries/{{{CountryIdParamName}}}";
  public const string CountryIdParamName = nameof(CountryId);

  public int CountryId { get; set; }
}
