using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface ICheckInRepository
    {
        Task<IEnumerable<CheckIn>> GetCheckInsByUserId(string userId);
        Task CreateCheckIn(CheckIn checkIn);
    }
}
