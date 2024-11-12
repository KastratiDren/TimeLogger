using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IServices
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
