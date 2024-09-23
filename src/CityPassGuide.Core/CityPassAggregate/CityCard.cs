using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class CityCard : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public City City { get; private set; }
  public DateRange ValidityPeriod { get; private set; }

  public CityCard(string name, City city, DateRange validityPeriod)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    City = city;
    ValidityPeriod = validityPeriod;
  }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
  private CityCard() { } // EF required
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateValidityPeriod(DateRange newValidityPeriod)
  {
    ValidityPeriod = newValidityPeriod;
  }
}
