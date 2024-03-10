using BudgetControl.Domain.Common.Models;

namespace BudgetControl.Domain.LedgerAggregate.Entities;

public sealed class LedgerCategory : Entity<Guid>
{
    public string Name { get; private set; }
    public float Goal { get; private set; }
    public string Color { get; private set; }
    public Guid LedgerId { get; private set; }
    private readonly List<CategoryGroup> _groups = new();

    public List<CategoryGroup> Groups => _groups.ToList();
    private LedgerCategory(Guid id,
                           string name,
                           float goal,
                           string color,
                           Guid ledgerId) : base(id)
    {
        Name = name;
        Goal = goal;
        Color = color;
        LedgerId = ledgerId;
    }

    public static LedgerCategory Create(string name,
                                        float goal,
                                        string color,
                                        Guid ledgerId,
                                        List<CategoryGroup>? groups = null)
    {
        var category = new LedgerCategory(Guid.NewGuid(),
                                          name,
                                          goal,
                                          color,
                                          ledgerId);
        if (groups is not null) category.AddGroups(groups);
        return category;
    }

    public void Update(LedgerCategory ledgerCategory)
    {
        Name = ledgerCategory.Name;
        Goal = ledgerCategory.Goal;
        Color = ledgerCategory.Color;
    }

    public void AddGroups(List<CategoryGroup> groups)
    {
        _groups.AddRange(groups);
    }

}