using Microsoft.EntityFrameworkCore;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;
using TimeLogger.Infrastructure.Data;

namespace TimeLogger.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>> GetAttendanceByUserIdAsync(string userId)
        {
            var attendanceRecords = await _context.CheckIns
                .Where(ci => ci.UserId == userId)
                .Select(ci => new
                {
                    ci.CheckInTime,
                    ci.OfficeId,
                    OfficeName = _context.Offices
                        .Where(o => o.Id == ci.OfficeId)
                        .Select(o => o.Name)
                        .FirstOrDefault(),
                    CheckOutTime = _context.CheckOuts
                        .Where(co => co.UserId == ci.UserId
                                && co.OfficeId == ci.OfficeId
                                && co.CheckOutTime > ci.CheckInTime
                                && co.CheckOutTime.Date == ci.CheckInTime.Date
                                )
                        .OrderBy(co => co.CheckOutTime)
                        .Select(co => co.CheckOutTime)
                        .FirstOrDefault(),
                    UserName = _context.Users
                        .Where(u => u.Id == ci.UserId)
                        .Select(u => u.UserName)
                        .FirstOrDefault()
                })
                .Select(result => new Attendance
                {
                    OfficeName = result.OfficeName,
                    CheckInTime = result.CheckInTime,
                    CheckOutTime = result.CheckOutTime,
                    UserName = result.UserName
                })
                .ToListAsync(); 

            return attendanceRecords;
        }

        public async Task<List<Attendance>> GetAttendanceByDateAsync(DateTime date)
        {
            var attendanceRecords = await _context.CheckIns
                .Where(ci => ci.CheckInTime.Date == date) // Filter by specific date
                .Select(ci => new
                {
                    ci.CheckInTime,
                    ci.OfficeId,
                    OfficeName = _context.Offices
                        .Where(o => o.Id == ci.OfficeId)
                        .Select(o => o.Name)
                        .FirstOrDefault(),
                    CheckOutTime = _context.CheckOuts
                        .Where(co => co.UserId == ci.UserId
                                    && co.OfficeId == ci.OfficeId
                                    && co.CheckOutTime > ci.CheckInTime
                                    && co.CheckOutTime.Date == ci.CheckInTime.Date)
                        .OrderBy(co => co.CheckOutTime)
                        .Select(co => co.CheckOutTime)
                        .FirstOrDefault(),
                    UserName = _context.Users
                        .Where(u => u.Id == ci.UserId)
                        .Select(u => u.UserName)
                        .FirstOrDefault()
                })
                .Select(result => new Attendance
                {
                    OfficeName = result.OfficeName,
                    CheckInTime = result.CheckInTime,
                    CheckOutTime = result.CheckOutTime,
                    UserName = result.UserName
                })
                .ToListAsync();

            return attendanceRecords;
        }

    }
}
