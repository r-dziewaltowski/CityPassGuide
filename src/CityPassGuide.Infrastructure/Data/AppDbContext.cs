using System.Reflection;
using Ardalis.SharedKernel;
using CityPassGuide.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using CityPassGuide.Core.CityPassAggregate;

namespace CityPassGuide.Infrastructure.Data;
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Contributor> Contributors => Set<Contributor>();
  public DbSet<CityPass> CityPasses => Set<CityPass>();
  public DbSet<Country> Countries => Set<Country>();
  public DbSet<City> Cities => Set<City>();
  public DbSet<Attraction> Attractions => Set<Attraction>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    DataSeeder.SeedData(modelBuilder);
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();
}
