using AutoMapper;
using CityPassGuide.UseCases.Profiles;

namespace CityPassGuide.UnitTests.UseCases.Profiles;

public static class AutoMapperConfig
{
  public static IMapper Initialize()
  {
    return new MapperConfiguration(mc => mc.AddMaps(typeof(CountryProfile).Assembly)).CreateMapper();
  }
}
