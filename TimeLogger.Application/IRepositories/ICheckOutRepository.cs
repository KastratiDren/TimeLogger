using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface ICheckOutRepository
    {
        Task AddAsync(CheckOut checkOut);
        Task<bool> DeleteAsync(int id);
        Task<CheckOut?> GetByIdAsync(int id);
        Task<IEnumerable<CheckOut>> GetAllAsync();
        Task<IEnumerable<CheckOut>> GetByUserIdAsync(string userId);
        Task<IEnumerable<CheckOut>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
