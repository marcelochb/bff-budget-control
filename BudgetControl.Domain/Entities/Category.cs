namespace BudgetControl.Domain.Entities;

public record Category {
    public string Name { get; set; } = null!;
    public double Goal { get; set; } = Double.MinValue;
    public string Color { get; set; } = null!;
     public List<Group> Groups { get; set; } = [];

}