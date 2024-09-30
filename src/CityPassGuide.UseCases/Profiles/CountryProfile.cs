using AutoMapper;
using CityPassGuide.Core.CityCardAggregate;
using CityPassGuide.UseCases.Countries;

namespace CityPassGuide.UseCases.Profiles;

public class CountryProfile : Profile
{
  public CountryProfile()
  {
    CreateMap<Country, CountryDto>();
  }
}
