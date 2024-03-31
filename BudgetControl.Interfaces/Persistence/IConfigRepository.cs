namespace BudgetControl.Interfaces.Persistence;

public interface IConfigRepository<T>
{
    Task<T?> GetById(Guid id);
    Task Add(T configId);
    Task Update(T configId);
    Task Remove(Guid id);
}
