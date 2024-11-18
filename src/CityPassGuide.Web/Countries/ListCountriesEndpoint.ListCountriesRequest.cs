using System.ComponentModel;

namespace CityPassGuide.Web.Countries;

public class ListCountriesRequest
{
    public const string Route = "/countries";
    public const string PageNumberParamName = nameof(PageNumber);
    public const string PageSizeParamName = nameof(PageSize);
    public const string NameParamName = nameof(Name);
    public const string SearchQueryParamName = nameof(SearchQuery);

    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 10;
    public const int MaxPageSize = 100;

    /// <summary>
    /// Positive page number of countries to be returned (default applied if not specified)
    /// </summary>
    [DefaultValue(DefaultPageNumber)]
    public int? PageNumber { get; set; }

    /// <summary>
    /// Positive page size of countries to be returned (default applied if not specified)
    /// </summary>
    [DefaultValue(DefaultPageSize)]
    public int? PageSize { get; set; }

    /// <summary>
    /// Value to filter countries by name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Value to search countries
    /// </summary>
    public string? SearchQuery { get; set; }

    public int AdjustedPageNumber => PageNumber ?? DefaultPageNumber;

    public int AdjustedPageSize => Math.Min(PageSize ?? DefaultPageSize, MaxPageSize);
}
