namespace TimeLogger.Infrastructure.Repositories
{
    public class RoomBookingRepository : IRoomBookingRepository
    {
        private readonly AppDbContext _context;

        public RoomBookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RoomBooking roomBooking)
        {
            await _context.RoomsBookings.AddAsync(roomBooking);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var roomBooking = await _context.RoomsBookings.FindAsync(id);
            if (roomBooking == null)
                return false;

            _context.RoomsBookings.Remove(roomBooking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoomBooking>> GetAllAsync()
        {
            return await _context.RoomsBookings
                .Include(rb => rb.Room)
                .ThenInclude(r => r.Office)
                .ToListAsync();
        }

        public async Task<RoomBooking?> GetByIdAsync(int id)
        {
            return await _context.RoomsBookings
                .Include(rb => rb.Room)
                .ThenInclude(r => r.Office)
                .FirstOrDefaultAsync(rb => rb.Id == id);
        }

        public async Task<IEnumerable<RoomBooking>> GetByRoomIdAsync(int roomId, DateTime? date = null)
        {
            var query = await _context.RoomsBookings
                .Where(rb => rb.RoomId == roomId )
                .Include(rb => rb.Room)
                .ThenInclude(r => r.Office)
                .ToListAsync();

            if (date.HasValue)
            {
                var selectedDate = date.Value.Date; // Ensure we only compare the date part
                return query.Where(rb =>rb.StartTime.Date == selectedDate || rb.EndTime.Date == selectedDate);
            }

            return query;
        }


        public async Task<bool> IsValidRoomBookingAsync(int bookingId)
        {
            return await _context.RoomsBookings.AnyAsync(rb => rb.Id == bookingId);
        }

        public async Task UpdateAsync(RoomBooking roomBooking)
        {
            _context.RoomsBookings.Update(roomBooking);
            await _context.SaveChangesAsync();
        }
    }
}
