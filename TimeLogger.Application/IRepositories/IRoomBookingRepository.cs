namespace TimeLogger.Application.IRepositories
{
    public interface IRoomBookingRepository
    {
        Task<IEnumerable<RoomBooking>> GetAllRoomBookings();
        Task<IEnumerable<RoomBooking>> GetRoomBookingByRoomId(int roomId, DateTime? date = null);
        Task CreateRoomBooking(RoomBooking roomBooking);
    }
}
