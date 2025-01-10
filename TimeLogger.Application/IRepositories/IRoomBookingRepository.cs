using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IRoomBookingRepository
    {
        Task AddAsync(RoomBooking roomBooking);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<RoomBooking>> GetAllAsync();
        Task<RoomBooking?> GetByIdAsync(int id);
        Task<IEnumerable<RoomBooking>> GetByRoomIdAsync(int roomId, DateTime? date = null);
        Task<bool> IsValidRoomBookingAsync(int bookingId);
        Task UpdateAsync(RoomBooking roomBooking);
    }
}
