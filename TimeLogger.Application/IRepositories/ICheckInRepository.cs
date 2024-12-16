using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface ICheckInRepository
    {
        Task AddAsync(CheckIn checkIn);
        Task<bool> DeleteAsync(int id);
        Task<CheckIn?> GetByIdAsync(int id);
        Task<IEnumerable<CheckIn>> GetAllAsync();
        Task<IEnumerable<CheckIn>> GetByUserIdAsync(string userId);
        Task<IEnumerable<CheckIn>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<CheckIn?> GetCheckinByDateAndOfficeAsync(DateTime date, int officeId);
    }
}
