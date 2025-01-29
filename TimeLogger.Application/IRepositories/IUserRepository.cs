namespace TimeLogger.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(string userId);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> DeleteUser(string userId);
    }
}
