using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task<bool> DeleteAsync(string userId);
    }
}
