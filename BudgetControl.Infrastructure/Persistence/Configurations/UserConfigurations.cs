using BudgetControl.Domain.ConfigAggregate;
using BudgetControl.Domain.UserAggregate;
using BudgetControl.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        UserCollectionConfiguration(builder);
    }


    private static void UserCollectionConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("UserId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.Status)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne<Config>()
            .WithOne()
            .HasForeignKey<User>(e => e.ConfigId)
            .IsRequired(false);

        builder.HasIndex(e => e.Email)
            .IsUnique();
        builder.HasIndex(e => e.Name)
            .IsUnique();
    }
}
