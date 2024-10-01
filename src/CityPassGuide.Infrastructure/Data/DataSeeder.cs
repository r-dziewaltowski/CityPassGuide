using CityPassGuide.Core.CityCardAggregate;
using Microsoft.EntityFrameworkCore;

namespace CityPassGuide.Infrastructure.Data;

public static class DataSeeder
{
  public static void SeedData(ModelBuilder modelBuilder)
  {
    Country uk = new("United Kingdom") { Id = 1 };
    Country france = new("France") { Id = 2 };
    Country poland = new("Poland") { Id = 3 };
    modelBuilder.Entity<Country>().HasData(uk, france, poland);

    City london = new("London", uk.Id, 25) { Id = 1 };
    City paris = new("Paris", france.Id, 30) { Id = 2 };
    City krakow = new("Krakow", poland.Id, 20) { Id = 3 };
    modelBuilder.Entity<City>().HasData(london, paris, krakow);

    Attraction londonEye = new("London Eye", london.Id, 40) { Id = 1 };
    Attraction tateGallery = new("Tate Gallery", london.Id, 30) { Id = 2 };
    Attraction towerOfLondon = new("Tower of London", london.Id, 35) { Id = 3 };

    Attraction louvreMuseum = new("Louvre Museum", paris.Id, 50) { Id = 4 };
    Attraction eiffelTower = new("Eiffel Tower", paris.Id, 60) { Id = 5 };
    Attraction arcDeTriomphe = new("Arc de Triomphe", paris.Id, 35) { Id = 6 };

    Attraction wawelCastle = new("Wawel Castle", krakow.Id, 30) { Id = 7 };
    Attraction sukiennice = new("Sukiennice", krakow.Id, 25) { Id = 8 };
    Attraction mariackiChurch = new("Mariacki Church", krakow.Id, 20) { Id = 9 };


    modelBuilder.Entity<Attraction>().HasData(londonEye, tateGallery, towerOfLondon,
                                              louvreMuseum, eiffelTower, arcDeTriomphe,
                                              wawelCastle, sukiennice, mariackiChurch);

    modelBuilder.Entity<CityCard>(e =>
    {
      e.HasData(
        new
        {
          Id = 1,
          Name = "London Card",
          CityId = london.Id,
          DurationInDays = 5,
          CoversTransport = false
        },
        new
        {
          Id = 2,
          Name = "Paris Card",
          CityId = paris.Id,
          DurationInDays = 3,
          CoversTransport = true
        },
        new
        {
          Id = 3,
          Name = "Krakow Card",
          CityId = krakow.Id,
          DurationInDays = 2,
          CoversTransport = true
        });

      DateOnly startDate = new(2024, 1, 1);
      e.OwnsOne(e => e.ValidityPeriod).HasData(
        new
        {
          CityCardId = 1,
          StartDate = startDate,
          EndDate = DateOnly.MaxValue,
        },
        new
        {
          CityCardId = 2,
          StartDate = startDate,
          EndDate = DateOnly.MaxValue,
        },
        new
        {
          CityCardId = 3,
          StartDate = startDate,
          EndDate = new DateOnly(2024, 12, 31),
        });
    });

    modelBuilder.Entity<CityCard>()
      .HasMany(e => e.Attractions)
      .WithMany(e => e.CityCards)
      .UsingEntity(e => e.HasData(
        new
        {
          CityCardsId = 1,
          AttractionsId = 1
        },
        new
        {
          CityCardsId = 1,
          AttractionsId = 2
        },
        new
        {
          CityCardsId = 1,
          AttractionsId = 3
        },
        new
        {
          CityCardsId = 2,
          AttractionsId = 4
        },
        new
        {
          CityCardsId = 2,
          AttractionsId = 5
        },
        new
        {
          CityCardsId = 3,
          AttractionsId = 7
        },
        new
        {
          CityCardsId = 3,
          AttractionsId = 8
        },
        new
        {
          CityCardsId = 3,
          AttractionsId = 9
        }));
  }
}
