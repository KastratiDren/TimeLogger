using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(string userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task UpdateUser(User user);
        Task<bool> DeleteUser(string userId);
    }
}
