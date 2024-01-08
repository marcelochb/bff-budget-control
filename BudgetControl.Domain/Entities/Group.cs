namespace BudgetControl.Domain.Entities;

public record Group {
    public string Name { get; set; } = null!;
    public double Goal { get; set; } = Double.MinValue;

}