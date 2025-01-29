namespace TimeLogger.Application.IRepositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room?> GetRoomById(int id);
        Task CreateRoom(Room room);
        Task<bool> IsRoomValid(int roomId);
    }
}
