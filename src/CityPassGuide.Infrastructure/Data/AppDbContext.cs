using System.Reflection;
using Ardalis.SharedKernel;
using CityPassGuide.Core.CityPassAggregate;
using CityPassGuide.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;

namespace CityPassGuide.Infrastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher? dispatcher)
    : DbContext(options)
{
    private readonly IDomainEventDispatcher? _dispatcher = dispatcher;

    public DbSet<Contributor> Contributors => Set<Contributor>();
    public DbSet<CityPass> CityPasses => Set<CityPass>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Attraction> Attractions => Set<Attraction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Set database collation to be case-insensitive, SQLite by default is case-sensitive
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

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

    public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}
