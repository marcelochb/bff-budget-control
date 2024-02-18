using BudgetControl.Domain.LedgerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class LedgerConfigurations : IEntityTypeConfiguration<Ledger>
{
    public void Configure(EntityTypeBuilder<Ledger> builder)
    {
        ConfigurationLedgerCollection(builder);
        ConfigurationCategoryCollection(builder);
        ConfigurationUserCollection(builder);
    }

    private void ConfigurationUserCollection(EntityTypeBuilder<Ledger> builder)
    {
        builder.OwnsOne(m => m.User, ub =>
        {
            ub.Property(e => e.Id)
                .HasElementName("_id")
                .ValueGeneratedNever();
        });
    }

    private void ConfigurationCategoryCollection(EntityTypeBuilder<Ledger> builder)
    {
        builder.OwnsMany(m => m.Categories, sb => 
        {
            sb.HasKey(e => e.Id);
            sb.Property(e => e.Id)
                .HasElementName("_id")
                .ValueGeneratedNever();
            sb.OwnsMany(g => g.Groups, gb =>
            {
                gb.HasKey(e => e.Id);
                gb.Property(e => e.Id)
                    .HasElementName("_id")
                    .ValueGeneratedNever();
            });
        });
    }

    private void ConfigurationLedgerCollection(EntityTypeBuilder<Ledger> builder)
    {
        builder.ToCollection("ledgers");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasElementName("_id")
            .ValueGeneratedNever();
        builder.Ignore(e => e.User);
    }
}
