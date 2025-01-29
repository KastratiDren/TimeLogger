namespace TimeLogger.Application.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(User user);
    }
}
