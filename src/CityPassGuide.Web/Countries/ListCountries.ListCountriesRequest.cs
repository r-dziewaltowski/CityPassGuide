namespace CityPassGuide.Web.Countries;

public class ListCountriesRequest
{
  public const string Route = "/Countries";
  public const string PageNumberParamName = nameof(PageNumber);
  public const string PageSizeParamName = nameof(PageSize);

  public int? PageNumber { get; set; }

  public int? PageSize { get; set; }
}
