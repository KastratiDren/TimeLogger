using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
