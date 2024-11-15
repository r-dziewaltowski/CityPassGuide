namespace CityPassGuide.Web.Countries;

public class ListCountriesRequest
{
  public const string Route = $"{EndpointConstants.ApiRoot}/countries";
  public const string PageNumberParamName = nameof(PageNumber);
  public const string PageSizeParamName = nameof(PageSize);

  public const int DefaultPageNumber = 1;
  public const int DefaultPageSize = 10;
  public const int MaxPageSize = 20;

  public int? PageNumber { get; set; }

  public int? PageSize { get; set; }

  public int GetAdjustedPageNumber()
  {
    return PageNumber ?? DefaultPageNumber;
  }

  public int GetAdjustedPageSize()
  {
    return Math.Min(PageSize ?? DefaultPageSize, MaxPageSize);
  }
}
