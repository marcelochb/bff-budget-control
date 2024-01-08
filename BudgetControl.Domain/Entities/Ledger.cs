namespace BudgetControl.Domain.Entities;

public record Ledger {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public bool Share { get; set; } = false;
    public List<string> SharedUsers { get; set; } = [];
    public List<Category> Categories { get; set; } = [];

}