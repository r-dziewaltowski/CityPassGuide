namespace CityPassGuide.Web.Countries;

public class GetCountryByIdRequest
{
  public const string Route = $"/Countries/{{{CountryIdParamName}}}";
  public const string CountryIdParamName = nameof(CountryId);

  public int CountryId { get; set; }
}
