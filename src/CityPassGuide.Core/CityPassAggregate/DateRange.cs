using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class DateRange : ValueObject
{
  public DateOnly StartDate { get; }
  public DateOnly EndDate { get; }

  public DateRange(DateOnly startDate, DateOnly? endDate = null)
  {
    EndDate = endDate ?? DateOnly.MaxValue;

    if ((StartDate = startDate) > EndDate)
    {
      throw new ArgumentException("startDate must be before or equal to endDate", nameof(startDate));    
    }
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return StartDate;
    yield return EndDate;
  }
}
