using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.IRepositories
{
    public interface IRoomRepository
    {
        Task AddAsync(Room room);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task<bool> IsValidRoomAsync(int roomId);
        Task UpdateAsync(Room room);
    }
}
