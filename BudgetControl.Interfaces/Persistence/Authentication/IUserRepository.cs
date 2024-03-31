namespace BudgetControl.Interfaces.Persistence.Authentication;

public interface IUserRepository<T>
{
    Task<T?> GetUserByEmail(string email);
    Task<T?> GetUserByName(string name);
    Task Add(T user);
    Task Update(T user);
    Task<T?> GetById(Guid id);

}