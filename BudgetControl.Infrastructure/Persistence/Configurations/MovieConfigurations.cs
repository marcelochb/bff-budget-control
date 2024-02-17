using BudgetControl.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BudgetControl.Infrastructure.Persistence.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToCollection("movies");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasElementName("_id")
            .ValueGeneratedNever()
            .HasConversion(
            guid => ObjectId.Parse(guid.ToString()),
            objectId => new Guid(objectId.ToString()));
    }
}
