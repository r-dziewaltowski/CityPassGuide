namespace CityPassGuide.Web;

public class PaginationMetadata(int pageNumber, int pageSize, int totalItemCount)
{
  public const string PaginationMetadataHeader = "X-Pagination";

  public int PageNumber { get; } = pageNumber;
  public int PageSize { get; } = pageSize;
  public int TotalItemCount { get; } = totalItemCount;
  public int TotalPageCount { get; } = (int)Math.Ceiling(totalItemCount / (double)pageSize);
}
