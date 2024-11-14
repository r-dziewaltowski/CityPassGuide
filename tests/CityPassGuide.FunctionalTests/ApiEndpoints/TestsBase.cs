using CityPassGuide.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace CityPassGuide.FunctionalTests.ApiEndpoints;

public class TestsBase
{
  protected readonly HttpClient Client;

  public TestsBase(CustomWebApplicationFactory<Program> factory)
  {
    Client = factory.CreateClient();
    CreateAndSeedDatabase(factory);
  }

  private static void CreateAndSeedDatabase(WebApplicationFactory<Program> factory)
  {
    using var scope = factory.Services.CreateScope();
    var scopedServices = scope.ServiceProvider;
    var db = scopedServices.GetRequiredService<AppDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
  }
}
