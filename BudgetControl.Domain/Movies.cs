using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain;
public sealed class Movie : AggregateRoot<Guid>
{
    public string Title { get; set; }
    public Movie(Guid id, string title) : base(id)
    {
        Title = title;
    }
    public static Movie Create(string title)
    {
        return new(
            Guid.NewGuid(),
            title);
    }

}