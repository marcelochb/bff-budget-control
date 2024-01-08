namespace BudgetControl.Interfaces.Persistence.Authentication;

public interface IUserRepository<T>
{
    T? GetUserByEmail(string email);
    void Add(T user);

}