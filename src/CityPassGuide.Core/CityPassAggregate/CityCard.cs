using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class CityCard(string name, City city, DateRange validityPeriod) : EntityBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public City City { get; } = city;
  public DateRange ValidityPeriod { get; private set; } = validityPeriod;
  //public ContributorStatus Status { get; private set; } = ContributorStatus.NotSet;
  //public PhoneNumber? PhoneNumber { get; private set; }

  //public void SetPhoneNumber(string phoneNumber)
  //{
  //  PhoneNumber = new PhoneNumber(string.Empty, phoneNumber, string.Empty);
  //}

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateValidityPeriod(DateRange newValidityPeriod)
  {
    ValidityPeriod = newValidityPeriod;
  }
}

//public class PhoneNumber : ValueObject
//{
//  public string CountryCode { get; private set; } = string.Empty;
//  public string Number { get; private set; } = string.Empty;
//  public string? Extension { get; private set; } = string.Empty;

//  public PhoneNumber(string countryCode,
//    string number,
//    string? extension)
//  {
//    CountryCode = countryCode;
//    Number = number;
//    Extension = extension;
//  }
//  protected override IEnumerable<object> GetEqualityComponents()
//  {
//    yield return CountryCode;
//    yield return Number;
//    yield return Extension ?? String.Empty;
//  }
//}
