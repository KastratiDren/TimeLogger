using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAttendanceByUserIdAsync(string userId);
    }
}
