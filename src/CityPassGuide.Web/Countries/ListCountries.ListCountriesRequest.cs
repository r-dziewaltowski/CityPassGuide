namespace CityPassGuide.Web.Countries;

public class ListCountriesRequest
{
  public const string Route = "/Countries";

  public static string BuildRoute(int pageNumber, int pageSize)
  {
    return Route
      .Replace("{PageNumber:int}", pageNumber.ToString())
      .Replace("{PageSize:int}", pageSize.ToString());
  }

  public int? PageNumber { get; set; }

  public int? PageSize { get; set; }
}
