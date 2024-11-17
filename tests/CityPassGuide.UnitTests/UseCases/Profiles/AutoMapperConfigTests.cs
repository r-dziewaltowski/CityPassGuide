using Xunit;

namespace CityPassGuide.UnitTests.UseCases.Profiles;

public class AutoMapperConfigTests
{
    [Fact]
    public void Initialize_ShouldCreateValidConfiguration()
    {
        // Act
        var mapper = AutoMapperConfig.Initialize();

        // Assert
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }
}
