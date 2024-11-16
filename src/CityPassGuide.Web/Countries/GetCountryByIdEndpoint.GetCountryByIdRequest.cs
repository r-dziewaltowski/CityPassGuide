namespace CityPassGuide.Web.Countries;

public class GetCountryByIdRequest
{
  public const string Route = $"/countries/{{{CountryIdParamName}}}";
  public const string CountryIdParamName = nameof(CountryId);

  /// <summary>
  /// Positive integer country ID
  /// </summary>
  public int CountryId { get; set; }
}
