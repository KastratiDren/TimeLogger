using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string userId);
        Task<IEnumerable<User>> GetAllAsync(string email);
        Task UpdateAsync(User user);
        Task<bool> DeleteAsync(string userId);
    }
}
