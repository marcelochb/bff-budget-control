namespace BudgetControl.Interfaces.Persistence.Authentication;

public interface IJwtTokenGenerator<T>
{
    string GeneratorToken(T user);
}