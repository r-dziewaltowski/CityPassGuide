namespace CityPassGuide.Web.Countries;

public class GetCountryByIdRequest
{
  public const string Route = "/Countries/{CountryId:int}";
  public static string BuildRoute(int countryId) => Route.Replace("{CountryId:int}", countryId.ToString());

  public int CountryId { get; set; }
}
