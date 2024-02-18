using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence;

public class BudgetControlDbContext : DbContext
{
    public BudgetControlDbContext(DbContextOptions<BudgetControlDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; init; }
    public DbSet<Ledger> Ledgers { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetControlDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}