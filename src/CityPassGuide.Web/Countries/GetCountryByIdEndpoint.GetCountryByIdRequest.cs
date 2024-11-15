namespace CityPassGuide.Web.Countries;

public class GetCountryByIdRequest
{
  public const string Route = $"/countries/{{{CountryIdParamName}}}";
  public const string CountryIdParamName = nameof(CountryId);

  public int CountryId { get; set; }
}
