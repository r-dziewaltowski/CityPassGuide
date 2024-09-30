using Xunit;

namespace CityPassGuide.UnitTests.UseCases.Profiles;

public class AutoMapperConfigurationTests
{
  [Fact]
  public void CreateValidMappingConfiguration()
  {
    var mapper = AutoMapperConfig.Initialize();

    mapper.ConfigurationProvider.AssertConfigurationIsValid();
  }
}
