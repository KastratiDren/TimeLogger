using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface ICheckOutRepository
    {
        Task<CheckOut?> GetCheckOutById(int id);
        Task<IEnumerable<CheckOut>> GetAllCheckOuts();
        Task<IEnumerable<CheckOut>> GetCheckOutsByUserId(string userId);
        Task<IEnumerable<CheckOut>> GetCheckOutsByDateRange(DateTime startDate, DateTime endDate);
        Task CreateCheckOut(CheckOut checkOut);
        Task<bool> DeleteCheckOut(int id);
    }
}
