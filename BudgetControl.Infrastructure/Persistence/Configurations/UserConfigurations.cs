using BudgetControl.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        UserCollectionConfiguration(builder);
        UserConfigCollectionConfiguration(builder);
    }

    private void UserConfigCollectionConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(e => e.Config, userConfig =>
        {
            userConfig.Property(e => e.Id)
                .HasElementName("_id")
                .ValueGeneratedNever();
            userConfig.Property(e => e.LedgerId);
        });
    }

    private static void UserCollectionConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.ToCollection("users");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasElementName("_id")
            .ValueGeneratedNever();
    }
}
