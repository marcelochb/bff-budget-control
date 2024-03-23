using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.ConfigAggregate.ValueObjects;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class ConfigConfigurations : IEntityTypeConfiguration<Config>
{
    public void Configure(EntityTypeBuilder<Config> builder)
    {
        ConfigureConfigTable(builder);
    }

    private void ConfigureConfigTable(EntityTypeBuilder<Config> builder)
    {
        builder.ToTable("Configs");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("ConfigId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ConfigId.Create(value)
            );
        builder.Property(e => e.LedgerId)
            .HasColumnName("LedgerId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => LedgerId.Create(value)
            );
    }
}