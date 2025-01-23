namespace TimeLogger.Infrastructure.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly AppDbContext _context;

        public CheckInRepository(AppDbContext context)
        {
            _context = context;
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
    }
}
