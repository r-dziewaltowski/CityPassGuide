using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace CityPassGuide.Core.CityPassAggregate;

public class CityPass : EntityBase
{
    public string Name { get; private set; }
    public int CityId { get; private set; }
    public DateRange ValidityPeriod { get; private set; }
    public int DurationInDays { get; private set; }
    public bool CoversTransport { get; private set; }

    private readonly List<Attraction> _attractions = [];
    public IEnumerable<Attraction> Attractions => _attractions.AsReadOnly();

    public CityPass(
        string name,
        int cityId,
        DateRange validityPeriod,
        int durationInDays,
        bool coversTransport,
        IEnumerable<Attraction> attractions)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name));
        CityId = Guard.Against.NegativeOrZero(cityId);
        ValidityPeriod = validityPeriod;
        DurationInDays = Guard.Against.NegativeOrZero(durationInDays);
        CoversTransport = coversTransport;

        if (attractions.Any(a => a.CityId != CityId))
        {
            throw new ArgumentException("Attractions must be in the covered city", nameof(attractions));
        }
        _attractions = attractions.ToList();
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private CityPass() { } // EF required
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
