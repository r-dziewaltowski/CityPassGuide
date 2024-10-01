using CityPassGuide.UseCases.Countries;

namespace CityPassGuide.Web.Countries;

public class ListCountriesResponse
{
  public List<CountryDto> Countries { get; set; } = [];
}
