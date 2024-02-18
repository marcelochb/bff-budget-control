namespace BudgetControl.Interfaces.Persistence.Authentication;

public interface IUserRepository<T>
{
    Task<T?> GetUserByEmail(string email);
    Task Add(T user);
    void Update(T user);
    T? Get(string id);

}