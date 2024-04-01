using BudgetControl.Domain.LedgerAggregate.Entities;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<LedgerCategory>
{
    public void Configure(EntityTypeBuilder<LedgerCategory> builder)
    {
        ConfigureCategoryTable(builder);
    }

    private static void ConfigureCategoryTable(EntityTypeBuilder<LedgerCategory> builder)
    {
        builder.ToTable("LedgerCategories");
        builder.HasKey(o => new { o.Id, o.LedgerId });
        builder.Property(e => e.Id)
            .HasColumnName("LedgerCategoryId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => LedgerCategoryId.Create(value)
            );
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Color)
            .HasMaxLength(7)
            .IsRequired();
        builder.Property(e => e.Goal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasMany(e => e.Groups)
            .WithOne()
            .HasForeignKey(o => new { o.LedgerCategoryId, o.LedgerId })
            .IsRequired(false);

        builder.HasIndex(e => e.Name)
            .IsUnique(false);
    }
}
