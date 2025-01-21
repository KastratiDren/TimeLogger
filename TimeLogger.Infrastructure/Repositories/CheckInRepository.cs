namespace TimeLogger.Infrastructure.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly AppDbContext _context;

        public CheckInRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CheckIn>> GetAllCheckIns()
        {
            var checkIns = await _context.CheckIns
                .Include(c => c.Office)
                .Include(c => c.User)
                .ToListAsync();

            return checkIns;
        }

        public async Task<CheckIn?> GetCheckInById(int id)
        {

            var checkIn = await _context.CheckIns
                .Include(c => c.Office)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);

            return checkIn;
        }

        public async Task<IEnumerable<CheckIn>> GetCheckInsByDateRange(DateTime startDate, DateTime endDate)
        {
            var checkIns = await _context.CheckIns
                .Where(c => c.CheckInTime >= startDate && c.CheckInTime <= endDate)
                .Include(c => c.Office)
                .Include(c => c.User)
                .OrderByDescending(c => c.CheckInTime)
                .ToListAsync();

            return checkIns;
        }

        public async Task<IEnumerable<CheckIn>> GetCheckInsByUserId(string userId)
        {
            var checkIns = await _context.CheckIns
                .Where(c => c.UserId == userId)
                .Include(c => c.Office)
                .OrderByDescending(c => c.CheckInTime)
                .ToListAsync();

            return checkIns;
        }

        public async Task CreateCheckIn(CheckIn checkIn)
        {
            await _context.CheckIns.AddAsync(checkIn);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCheckIn(int id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null)
                return false;

            _context.CheckIns.Remove(checkIn);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
