using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IRoomBookingRepository
    {
        Task<RoomBooking?> GetRoomBookingById(int id);
        Task<IEnumerable<RoomBooking>> GetAllRoomBookings();
        Task<IEnumerable<RoomBooking>> GetRoomBookingByRoomId(int roomId, DateTime? date = null);
        Task CreateRoomBooking(RoomBooking roomBooking);
        Task UpdateRoomBooking(RoomBooking roomBooking);
        Task<bool> DeleteRoomBooking(int id);
        Task<bool> IsRoomBookingValid(int bookingId);
    }
}
