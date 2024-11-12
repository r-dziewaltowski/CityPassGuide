using AutoMapper;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.UseCases.Profiles;

public class CountryProfile : Profile
{
  public CountryProfile()
  {
    CreateMap<Country, CountryDto>();
  }
}
