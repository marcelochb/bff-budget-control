using BudgetControl.Domain.Common.Models;
using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence;

public class BudgetControlDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptors _publishDomainEventsInterceptors;
    public BudgetControlDbContext(DbContextOptions<BudgetControlDbContext> options, 
                        PublishDomainEventsInterceptors publishDomainEventsInterceptors) : base(options)
    {
        _publishDomainEventsInterceptors = publishDomainEventsInterceptors;
    }
    public DbSet<User> Users { get; init; }
    public DbSet<Ledger> Ledgers { get; init; }
    public DbSet<LedgerCategory> Categories { get; init; }
    public DbSet<CategoryGroup> Groups { get; init; }
    public DbSet<Config> Configs { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(BudgetControlDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptors);
        base.OnConfiguring(optionsBuilder);
    }
}