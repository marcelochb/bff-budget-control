using BudgetControl.Domain;
using Microsoft.EntityFrameworkCore;

namespace BudgetControl.Infrastructure.Persistence;

public class BudgetControlDbContext : DbContext
{
    public BudgetControlDbContext(DbContextOptions<BudgetControlDbContext> options) : base(options)
    {
    }
    public DbSet<Movie> Movies { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetControlDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}