namespace TimeLogger.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = await _context.Rooms
                .Include(r => r.Office)
                .Include(r => r.RoomBookings)
                .ToListAsync();

            return rooms;
        }

        public async Task<Room?> GetRoomById(int id)
        {
            var room = await _context.Rooms
                .Include(r => r.Office)
                .Include(r => r.RoomBookings)
                .FirstOrDefaultAsync(r => r.Id == id);

            return room;
        }

        public async Task CreateRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsRoomValid(int roomId)
        {
            return await _context.Rooms.AnyAsync(r => r.Id == roomId);
        }
    }
}
