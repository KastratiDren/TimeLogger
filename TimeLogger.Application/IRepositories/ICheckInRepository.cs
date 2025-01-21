using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface ICheckInRepository
    {
        Task<CheckIn?> GetCheckInById(int id);
        Task<IEnumerable<CheckIn>> GetAllCheckIns();
        Task<IEnumerable<CheckIn>> GetCheckInsByUserId(string userId);
        Task<IEnumerable<CheckIn>> GetCheckInsByDateRange(DateTime startDate, DateTime endDate);
        Task CreateCheckIn(CheckIn checkIn);
        Task<bool> DeleteCheckIn(int id);
    }
}
