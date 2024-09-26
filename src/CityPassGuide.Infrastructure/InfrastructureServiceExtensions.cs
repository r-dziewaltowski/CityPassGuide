using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using CityPassGuide.Core.Interfaces;
using CityPassGuide.Core.Services;
using CityPassGuide.Infrastructure.Data;
using CityPassGuide.Infrastructure.Data.Queries;
using CityPassGuide.Infrastructure.Email;
using CityPassGuide.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CityPassGuide.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger,
    bool isDevelopment)
  {
    string? connectionString = config.GetConnectionString("SqliteConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseSqlite(connectionString)
      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
      .EnableSensitiveDataLogging(isDevelopment));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
