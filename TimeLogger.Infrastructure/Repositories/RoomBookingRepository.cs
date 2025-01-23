namespace TimeLogger.Infrastructure.Repositories
{
    public class RoomBookingRepository : IRoomBookingRepository
    {
        private readonly AppDbContext _context;

        public RoomBookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomBooking>> GetAllRoomBookings()
        {
            var roomBookings = await _context.RoomsBookings
                .Include(rb => rb.Room)
                .ThenInclude(r => r.Office)
                .ToListAsync();

            return roomBookings;
        }

        public async Task<IEnumerable<RoomBooking>> GetRoomBookingByRoomId(int roomId, DateTime? date = null)
        {
            var roomBookings = await _context.RoomsBookings
                .Where(rb => rb.RoomId == roomId)
                .Include(rb => rb.Room)
                .ThenInclude(r => r.Office)
                .ToListAsync();

            if (date.HasValue)
            {
                var selectedDate = date.Value.Date;
                return roomBookings.Where(rb => rb.StartTime.Date == selectedDate || rb.EndTime.Date == selectedDate);
            }

            return roomBookings;
        }

        public async Task CreateRoomBooking(RoomBooking roomBooking)
        {
            await _context.RoomsBookings.AddAsync(roomBooking);
            await _context.SaveChangesAsync();
        }
    }
}
