using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class GroupConfigurations : IEntityTypeConfiguration<CategoryGroup>
{
    public void Configure(EntityTypeBuilder<CategoryGroup> builder)
    {
        ConfigureGroupTable(builder);
    }

    private static void ConfigureGroupTable(EntityTypeBuilder<CategoryGroup> builder)
    {
        builder.ToTable("CategoryGroups");
        builder.HasKey(o => new { o.Id, o.LedgerCategoryId, o.LedgerId });
        builder.Property(e => e.Id)
            .HasColumnName("CategoryGroupId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CategoryGroupId.Create(value)
            );
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Goal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        builder.HasIndex(e => e.Name)
            .IsUnique(false);

    }
}
