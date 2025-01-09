using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAttendanceByUserIdAsync(string userId);
        Task<List<Attendance>> GetAttendanceByDateAsync(DateTime date);
        Task<TimeSpan> GetWeeklyWorkHoursAsync(string userId, DateTime startOfWeek, DateTime endOfWeek);
        Task<TimeSpan> GetMonthlyWorkDurationAsync(string userId);


    }
}
