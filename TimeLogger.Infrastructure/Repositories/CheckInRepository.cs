namespace TimeLogger.Infrastructure.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly AppDbContext _context;

        public CheckInRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CheckIn checkIn)
        {
            await _context.CheckIns.AddAsync(checkIn);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null)
                return false;

            _context.CheckIns.Remove(checkIn);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CheckIn>> GetAllAsync()
        {
            return await _context.CheckIns
                .Include(c => c.Office)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<CheckIn?> GetByIdAsync(int id)
        {
            return await _context.CheckIns
                .Include(c => c.Office)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CheckIn>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.CheckIns
                .Where(c => c.CheckInTime >= startDate && c.CheckInTime <= endDate)
                .Include(c => c.Office)
                .Include(c => c.User)
                .OrderByDescending(c => c.CheckInTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<CheckIn>> GetByUserIdAsync(string userId)
        {
            return await _context.CheckIns
                .Where(c => c.UserId == userId)
                .Include(c => c.Office)
                .OrderByDescending(c => c.CheckInTime)
                .ToListAsync();
        }

    }
}
