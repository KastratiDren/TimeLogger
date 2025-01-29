namespace TimeLogger.Application.IRepositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAttendancesByUserId(string userId);
        Task<List<Attendance>> GetAttendancesByDate(DateTime date);
        Task<TimeSpan?> GetTotalWorkDurationByUserId(string userId, DateTime startDate, DateTime endDate);
    }
}
