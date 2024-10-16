using BudgetControl.Domain.LedgerAggregate;
using BudgetControl.Domain.LedgerAggregate.ValueObjects;
using BudgetControl.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class LedgerConfigurations : IEntityTypeConfiguration<Ledger>
{
    public void Configure(EntityTypeBuilder<Ledger> builder)
    {
        ConfigureLedgerTable(builder);
    }
    private void ConfigureLedgerTable(EntityTypeBuilder<Ledger> builder)
    {
        builder.ToTable("Ledgers");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => LedgerId.Create(value)
            );

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.HasMany(e => e.Categories)
            .WithOne()
            .HasForeignKey(o => o.LedgerId)
            .IsRequired(false);

        builder.HasMany(e => e.UsersShare)
            .WithMany(x => x.SharedLedgers)
            .UsingEntity(j => j.ToTable("UsersSharingLedgers"));


            
        builder.Property(e => e.Name)
            .HasMaxLength(100);
        builder.Property(e => e.Type)
            .HasMaxLength(100);
        
        builder.HasIndex(e => e.Name)
            .IsUnique(false);
    }
}
